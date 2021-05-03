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
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;
        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet("GetAllPhotos")]
        public async Task<ActionResult<PhotosDtoResponse>> GetAllPhotos()
        {
            try
            {
                return Ok(await _photoService.GetAllPhotosAsync());
            }
            catch (Exception ex)
            {
                return Problem();
            }

        }
    }
}
