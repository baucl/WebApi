using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Interfaces;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAllPost")]
        public async Task<ActionResult<PostsDtoResponse>> GetAllPost(string userId)
        {
            try
            {
                return Ok(await _postService.GetAllPostAsync(userId));
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpGet("GetPostById/{postId}")]
        public async Task<ActionResult<PostsDtoResponse>> GetPostByNumber(string postId)
        {
            try
            {
                return Ok(await _postService.GetPostByNumberAsync(postId));
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpGet("GetPostCommentsByNumber/{postId}/comments")]
        public async Task<ActionResult<CommentsDtoResopnse>> GetPostCommentsByNumber(string postId)
        {
            try
            {
                return Ok(await _postService.GetPostCommentsByNumberAsync(postId));
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpPost("CreateNewPost")]
        public async Task<ActionResult<PostsDtoCreateResponse>> CreateNewPost(PostsDtoRequest request)
        {
            try
            {
                if (request is null)
                {
                    return NoContent();
                }
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }
                else
                {
                    return Ok(await _postService.CreateNewPost(request));
                }
                
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpPut("UpdatePost")]
        public async Task<ActionResult<PostsDtoUpdateResponse>> UpdatePost(PostsUpdateDtoRequest request)
        {
            try
            {
                if (request is null)
                {
                    return NoContent();
                }
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }
                else
                {
                    return Ok(await _postService.UpdatePost(new PostsUpdateDtoRequest
                    {
                        id = request.id,
                        title = request.title,
                        body = request.body,
                        userId = request.userId
                    }));
                }
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpPatch("UpdateResourcePost/{id}")]
        public async Task<ActionResult<PostsDtoUpdateResponse>> UpdateResourcePost(PostsUpdateResourceDtoRequest request, string id)
        {
            try
            {
                if (request is null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(await _postService.UpdateResourcePost(request, id));
                }
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpDelete("DeletePost/{id}")]
        public async Task<ActionResult<PostsDtoResponse>> DeletePost(string id)
        {
            try
            {
                return Ok(await _postService.DeletePost(id));
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
    }
}
