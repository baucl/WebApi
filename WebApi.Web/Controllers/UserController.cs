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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<UsersDtoResponse>> GetAllUsers()
        {
            try
            {
                return Ok(await _userService.GetAllUsersAsync());
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpGet("GetUserAlbumById/{id}")]
        public async Task<ActionResult<UsersDtoAlbumsResponse>> GetUserAlbumById(string id)
        {
            try
            {
                return Ok(await _userService.GetUserAlbumByIdsAsync(id));
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpGet("GetUserTodosById/{id}")]
        public async Task<ActionResult<UsersDtoTodosResponse>> GetUserTodosById(string id)
        {
            try
            {
                return Ok(await _userService.GetUserTodosByIdsAsync(id));
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpGet("GetUserPostsById/{id}")]
        public async Task<ActionResult<UsersDtoPostsResponse>> GetUserPostsById(string id)
        {
            try
            {
                return Ok(await _userService.GetUserPostsByIdsAsync(id));
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

    }
}
