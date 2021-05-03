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
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }


        [HttpGet("GetAllTodos")]
        public async Task<ActionResult<TodosDtoResponse>> GetAllTodos()
        {
            try
            {
                return Ok(await _todoService.GetAllTodosAsync());
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
    }
}
