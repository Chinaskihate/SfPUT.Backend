using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SfPUT.Backend.Application.Common.Posts;
using SfPUT.Backend.Application.Common.Tags;
using SfPUT.Backend.Application.Interfaces.Photos;
using SfPUT.Backend.Application.Interfaces.Posts;

namespace SfPUT.Backend.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class PostController : BaseController
    {
        private readonly IPostService _postService;
        private readonly IPhotoService _photoService;

        public PostController(IPostService postService, IPhotoService photoService)
        {
            _postService = postService;
            _photoService = photoService;
        }

        [HttpPut("CreatePost")]
        public async Task<ActionResult<Guid>> CreatePost(CreatePostDto dto)
        {
            var res = await _postService.CreatePost(dto, UserId, Username);
            return Ok(res);
        }

        [HttpDelete("DeletePost")]
        public async Task<ActionResult<bool>> DeletePost(Guid postId)
        {
            var res = await _postService.DeletePost(postId, UserId);
            return Ok(res);
        }

        [HttpPut("UpdatePost")]
        public async Task<ActionResult<bool>> UpdatePost(UpdatePostDto dto)
        {
            var res = await _postService.UpdatePost(dto, UserId);
            return Ok(res);
        }

        [HttpPost("GetPosts")]
        public async Task<ActionResult<IEnumerable<PostVm>>> GetPosts(GetPostDto dto)
        {
            var res = await _postService.GetPosts(dto);
            return Ok(res);
        }

        [HttpGet("GetCommentedPosts")]
        public async Task<ActionResult<IEnumerable<PostVm>>> GetCommentedPosts()
        {
            var res = await _postService.GetCommentedPosts(UserId);
            return Ok(res);
        }

        [HttpGet("GetRatedPosts")]
        public async Task<ActionResult<IEnumerable<PostVm>>> GetRatedPosts()
        {
            var res = await _postService.GetRatedPosts(UserId);
            return Ok(res);
        }

        [HttpGet("GetUserPosts")]
        public async Task<ActionResult<IEnumerable<PostVm>>> GetUserPosts()
        {
            var res = await _postService.GetUserPosts(UserId);
            return Ok(res);
        }

        [HttpGet("GetLikedPosts")]
        public async Task<ActionResult<IEnumerable<PostVm>>> GetLikedPosts()
        {
            var res = await _postService.GetLikedPosts(UserId);
            return Ok(res);
        }

        [HttpPost("SavePhoto")]
        public async Task<ActionResult<bool>> SavePhoto(Guid postId)
        {
            var result = await _photoService.SavePhoto(UserId, postId, Request.Form.Files[0]);
            return Ok(result);
        }

        [HttpGet("DownloadPhoto")]
        public async Task<ActionResult<bool>> DownloadPhoto(Guid postId)
        {
            var result = await _photoService.DownloadPhoto(postId);
            return result == null ? NotFound(postId) : File(result, "image/png");
        }
    }
}
