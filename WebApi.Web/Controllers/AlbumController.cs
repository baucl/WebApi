using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Interfaces;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet("GetAllAlbums")]
        public async Task<ActionResult<AlbumsDtoResponse>> GetAllAlbums()
        {
            try
            {
                return Ok(await _albumService.GetAllAlbumsAsync());
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
    }
}
