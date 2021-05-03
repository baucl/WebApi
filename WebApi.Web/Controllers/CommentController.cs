using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Interfaces;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("GetAllComments")]
        public async Task<ActionResult<CommentsDtoResopnse>> GetAllComments()
        {
            try
            {
                return Ok(await _commentService.GetAllCommentsAsync());
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpGet("GetCommentsByPostId/{postId}")]
        public async Task<ActionResult<CommentsDtoResopnse>> GetCommentsByPostId(string postId)
        {
            try
            {
                return Ok(await _commentService.GetCommentsByPostIdAsync(postId));
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
    }
}
