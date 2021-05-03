using System;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Interfaces
{
    public interface IAutheticateService
    {
        public dynamic GetSecuritytoken(string userName);
    }
}
