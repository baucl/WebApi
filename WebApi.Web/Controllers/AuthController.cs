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
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAutheticateService _authenticateService;
        public AuthController(IAutheticateService autheticateService)
        {
            _authenticateService = autheticateService;
        }

        [HttpPost("GetToken")]
        public IActionResult Authenticate(AuthenticationDto request)
        {
            try
            {
                var result = _authenticateService.GetSecuritytoken(request.username);
                return !ReferenceEquals(string.Empty, result) ? Ok(result) : Unauthorized();
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
    }
}
