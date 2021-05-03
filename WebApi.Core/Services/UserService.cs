using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Interfaces;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Services
{
    public class UserService: IUserService
    {
        private readonly IUsersRepository _userRepository;
        public UserService(IUsersRepository usersRepository)
        {
            _userRepository = usersRepository;
        }

        public async Task<UsersDtoResponse> GetAllUsersAsync()
        {
            var result = await _userRepository.GetAllUsersAsync();
            return result.Success
                ?
                 new UsersDtoResponse
                 {
                     Value = result.Value,
                     Success = true,
                     ErrorList = null
                 }
                 :
                 new UsersDtoResponse
                 {
                     Value = null,
                     Success = false,
                     ErrorList = result.ErrorList
                 };
        }

        public async Task<UsersDtoAlbumsResponse> GetUserAlbumByIdsAsync(string id)
        {
            var result = await _userRepository.GetUserAlbumByIdsAsync(id);
            if (result.Success)
            {
                return new UsersDtoAlbumsResponse
                {
                    Value = result.Value,
                    Success = true,
                    ErrorList = null
                };
            }
            else
            {
                return new UsersDtoAlbumsResponse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
            }
        }

        public async Task<UsersDtoTodosResponse> GetUserTodosByIdsAsync(string id)
        {
            var result = await _userRepository.GetUserTodosByIdsAsync(id);
            if (result.Success)
            {
                return new UsersDtoTodosResponse
                {
                    Value = result.Value,
                    Success = true,
                    ErrorList = null
                };
            }
            else
            {
                return new UsersDtoTodosResponse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
            }
        }

        public async Task<UsersDtoPostsResponse> GetUserPostsByIdsAsync(string id)
        {
            var result = await _userRepository.GetUserPostsByIdsAsync(id);
            if (result.Success)
            {
                return new UsersDtoPostsResponse
                {
                    Value = result.Value,
                    Success = true,
                    ErrorList = null
                };
            }
            else
            {
                return new UsersDtoPostsResponse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
            }
        }
    }
}
