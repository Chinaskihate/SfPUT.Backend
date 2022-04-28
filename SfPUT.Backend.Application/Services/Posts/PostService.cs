﻿using AutoMapper;
using SfPUT.Backend.Application.Common.Posts;
using SfPUT.Backend.Application.Common.Tags;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Application.Interfaces.Posts;
using SfPUT.Backend.Application.Interfaces.Sections;
using SfPUT.Backend.Application.Interfaces.Tags;
using SfPUT.Backend.Application.Interfaces.Users;
using SfPUT.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SfPUT.Backend.Application.Common.Exceptions;
using SfPUT.Backend.Application.Interfaces.Comments;
using SfPUT.Backend.Application.Interfaces.Likes;
using SfPUT.Backend.Application.Interfaces.Rates;

namespace SfPUT.Backend.Application.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostDataService _postDataService;
        private readonly IUserService _userService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        private readonly ISectionService _sectionService;
        private readonly ILikeService _likeService;
        private readonly ICommentService _commentService;
        private readonly IRateService _rateService;

        // TODO#5: change number of dependencies.
        public PostService(IPostDataService postDataService,
            IUserService userService,
            ITagService tagService,
            IMapper mapper,
            ISectionService sectionService,
            ILikeService likeService,
            ICommentService commentService,
            IRateService rateService)
        {
            _postDataService = postDataService;
            _userService = userService;
            _tagService = tagService;
            _mapper = mapper;
            _sectionService = sectionService;
            _likeService = likeService;
            _commentService = commentService;
            _rateService = rateService;
        }

        public async Task<Guid> CreatePost(Guid userId, Guid sectionId, string title, string sellerLink, string description, IEnumerable<Guid> tagsIds)
        {
            // TODO#8: move out all checks to some methods or to services.
            var user = await _userService.GetUserById(userId);
            // TODO#10: think about ALL await usings in solution.
            await ThrowExceptionIfHavePostWithTitle(user.Id, title);
            var section = await _sectionService.Get(sectionId);
            var tags = await _tagService.GetTags(tagsIds);
            var newPost = new Post()
            {
                Id = Guid.NewGuid(),
                Comments = new List<Comment>(),
                User = user,
                Info = new PostInfo()
                {
                    CreationTime = DateTime.Now,
                    Description = description,
                    LastEditTime = DateTime.Now,
                    SellerLink = sellerLink,
                    Title = title
                },
                Rates = new List<Rate>(),
                Section = section,
                Tags = tags.ToList()
            };
            await _postDataService.Create(newPost);
            _tagService.AddPostToTags(newPost, tags);
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

        public async Task<bool> UpdatePost(Guid postId, Guid userId, 
            string sellerLink, string description,
            IEnumerable<Guid> tagsIds)
        {
            var post = await _postDataService.Get(postId);
            if (post.User.Id != userId)
            {
                throw new EditingNotUserOwnPostException(userId: userId, postId: postId);
            }

            var tags = await _tagService.GetTags(tagsIds);
            if (DateTime.Now - post.Info.CreationTime > TimeSpan.FromDays(1))
            {
                throw new PostEditTimeoutException(post.Id, post.Info.CreationTime, DateTime.Now);
            }

            post.Info.LastEditTime = DateTime.Now;
            post.Info.Description = description;
            post.Info.SellerLink = sellerLink;
            post.Tags = tags.ToList();
            _tagService.AddPostToTags(post, tags);
            await _postDataService.Update(post.Id, post);
            return true;
        }

        public async Task<IEnumerable<PostVm>> GetPosts(string title, IEnumerable<Guid> tagsIds, double minRate, Guid sectionId, DateTime creationTime)
        {
            var tagsId = new HashSet<Guid>((await _tagService.GetTags(tagsIds))
                .Select(t => t.Id));
            var section = await _sectionService.Get(sectionId);
            var posts = section.Posts
                .Where(p => p.Info.Title.Contains(title) &&
                            p.Info.CreationTime > creationTime &&
                            tagsIds.Intersect(p.Tags.Select(t => t.Id)).Any());
            var postsVms = posts.Select(p => _mapper.Map<PostVm>(p))
                .Where(vm => vm.Rate >= minRate);
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