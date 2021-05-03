using System;
using System.Threading.Tasks;
using WebApi.Core.Interfaces;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Services
{
    public class AuthenticateService : IAutheticateService
    {
        private readonly IAuthenticateRepository _authenticateRepository;
        public AuthenticateService(IAuthenticateRepository authenticateRepository)
        {
            _authenticateRepository = authenticateRepository;
        }

        public dynamic GetSecuritytoken(string userName)
            => userName == "string" ? new TokenDto { token =  _authenticateRepository.GenerateSecurityToken(userName) } : "Usuario y/o contraseña son invalidos";
    }
}
