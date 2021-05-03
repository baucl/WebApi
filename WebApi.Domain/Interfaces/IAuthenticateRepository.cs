using System;

namespace WebApi.Domain.Interfaces
{
    public interface IAuthenticateRepository
    {
        public string GenerateSecurityToken(string userName);
    }
}
