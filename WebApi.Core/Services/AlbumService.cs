using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Interfaces;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Services
{
    public class AlbumService: IAlbumService
    {
        private readonly IAlbumsRepository _albumRespository;
        public AlbumService(IAlbumsRepository albumsRepository)
        {
            _albumRespository = albumsRepository;
        }

        public async Task<AlbumsDtoResponse> GetAllAlbumsAsync()
        {
            var result = await _albumRespository.GetAllAlbumsAsync();

            if (result.Success)
            {
                return new AlbumsDtoResponse
                {
                    Value = result.Value,
                    Success = true,
                    ErrorList = null
                };
            }
            else
            {
                return new AlbumsDtoResponse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
            }
        }

    }
}
