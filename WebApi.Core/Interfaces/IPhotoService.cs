using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Interfaces
{
    public interface IPhotoService
    {
        public Task<PhotosDtoResponse> GetAllPhotosAsync();
    }
}
