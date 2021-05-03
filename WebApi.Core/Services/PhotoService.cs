using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Interfaces;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotosRepository _photoRepository;
        public PhotoService(IPhotosRepository photosRepository)
        {
            _photoRepository = photosRepository;
        }

        public async Task<PhotosDtoResponse> GetAllPhotosAsync()
        {
            var result = await _photoRepository.GetAllPhotosAsync();
            if (result.Success)
            {
                return new PhotosDtoResponse
                {
                    Value = result.Value,
                    Success = true,
                    ErrorList = null
                };
            }
            else
            {
                return new PhotosDtoResponse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
            }
        }
    }
}
