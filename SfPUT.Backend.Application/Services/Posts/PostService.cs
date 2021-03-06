using AutoMapper;
using SfPUT.Backend.Application.Common.Exceptions;
using SfPUT.Backend.Application.Common.Posts;
using SfPUT.Backend.Application.Interfaces.Comments;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Application.Interfaces.Likes;
using SfPUT.Backend.Application.Interfaces.Posts;
using SfPUT.Backend.Application.Interfaces.Rates;
using SfPUT.Backend.Application.Interfaces.Sections;
using SfPUT.Backend.Application.Interfaces.Tags;
using SfPUT.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostDataService _postDataService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        private readonly ISectionService _sectionService;
        private readonly ILikeService _likeService;
        private readonly ICommentService _commentService;
        private readonly IRateService _rateService;
        
        public PostService(IPostDataService postDataService,
            ITagService tagService,
            IMapper mapper,
            ISectionService sectionService,
            ILikeService likeService,
            ICommentService commentService,
            IRateService rateService)
        {
            _postDataService = postDataService;
            _tagService = tagService;
            _mapper = mapper;
            _sectionService = sectionService;
            _likeService = likeService;
            _commentService = commentService;
            _rateService = rateService;
        }

        public async Task<Guid> CreatePost(CreatePostDto dto, Guid userId, string username)
        {
            await ThrowExceptionIfHavePostWithTitle(userId, dto.Title);
            var section = await _sectionService.Get(dto.SectionId);
            var tags = await _tagService.GetTags(dto.TagsIds);
            var user = new User()
            {
                Id = userId,
                Username = username
            };
            var newPost = new Post()
            {
                Id = Guid.NewGuid(),
                Comments = new List<Comment>(),
                User = user,
                Info = new PostInfo()
                {
                    CreationTime = DateTime.Now,
                    Description = dto.Description,
                    LastEditTime = DateTime.Now,
                    SellerLink = dto.SellerLink,
                    Title = dto.Title
                },
                Rates = new List<Rate>(),
                Section = section,
                Tags = tags.ToList()
            };
            await _postDataService.Create(newPost);
            return newPost.Id;
        }

        public async Task<bool> DeletePost(Guid postId, Guid userId)
        {
            var post = await _postDataService.Get(postId);
            if (post.User.Id != userId)
            {
                throw new EditingNotUserOwnPostException(userId: userId, postId: postId);
            }

            return await _postDataService.Delete(postId);
        }

        public async Task<bool> UpdatePost(UpdatePostDto dto, Guid userId)
        {
            var post = await _postDataService.Get(dto.PostId);
            if (post.User.Id != userId)
            {
                throw new EditingNotUserOwnPostException(userId: userId, postId: dto.PostId);
            }

            var tags = await _tagService.GetTags(dto.TagsIds);
            if (DateTime.Now - post.Info.CreationTime > TimeSpan.FromDays(1))
            {
                throw new PostEditTimeoutException(post.Id, post.Info.CreationTime, DateTime.Now);
            }

            post.Info.LastEditTime = DateTime.Now;
            post.Info.Description = dto.Description;
            post.Info.SellerLink = dto.SellerLink;
            post.Tags = tags.ToList();
            await _postDataService.Update(post.Id, post);
            return true;
        }

        public async Task<IEnumerable<PostVm>> GetPosts(GetPostDto dto)
        {
            dto.Title ??= string.Empty;
            var tagsIds = new HashSet<Guid>((await _tagService.GetTags(dto.TagsIds))
                .Select(t => t.Id));
            var section = await _sectionService.Get(dto.SectionId);
            var filteredPosts = section.Posts
                .Where(p => p.Info.Title.Contains(dto.Title) &&
                            p.Info.CreationTime > dto.CreationTime);
            if (dto.TagsIds.Any())
            {
                filteredPosts = filteredPosts
                    .Where(p => tagsIds
                        .IsSubsetOf(new HashSet<Guid>(p.Tags
                            .Select(t => t.Id))));
            }
            var postsVms = filteredPosts.Select(p => _mapper.Map<PostVm>(p))
                .Where(vm => vm.Rate >= dto.MinRate);
            return postsVms;
        }
        
        public async Task<IEnumerable<PostVm>> GetCommentedPosts(Guid userId)
        {
            return (await _commentService.GetUserComments(userId))
                .Select(c => _mapper.Map<PostVm>(c.Post));
            
        }

        public async Task<IEnumerable<PostVm>> GetRatedPosts(Guid userId)
        {
            return (await _rateService.GetUserRates(userId))
                .Select(r => _mapper.Map<PostVm>(r.Post));
        }

        public async Task<IEnumerable<PostVm>> GetUserPosts(Guid userId)
        {
            return (await _postDataService.GetUserPosts(userId))
                .Select(p => _mapper.Map<PostVm>(p));
        }

        public async Task<IEnumerable<PostVm>> GetLikedPosts(Guid userId)
        {
            var likes = await _likeService.GetUserLikes(userId);
            var postsId = new HashSet<Guid>(likes.Select(l => l.PostId));
            return (await _postDataService.GetAll())
                .Where(p => postsId.Contains(p.Id))
                .Select(p => _mapper.Map<PostVm>(p));
        }

        private async Task ThrowExceptionIfHavePostWithTitle(Guid userId, string title)
        {
            var posts = await _postDataService.GetUserPosts(userId);
            if (posts.Any(x => x.Info.Title.Equals(title)))
            {
                throw new PostAlreadyExistsException(userId, title);
            }
        }
    }
}
