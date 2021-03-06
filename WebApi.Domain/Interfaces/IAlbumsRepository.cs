using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Domain.Interfaces
{
    public interface IAlbumsRepository
    {
        public Task<OperationResult<List<AlbumsDto>>> GetAllAlbumsAsync();
    }
}
