using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Interfaces
{
    public interface IUserService
    {
        public Task<UsersDtoResponse> GetAllUsersAsync();
        public Task<UsersDtoAlbumsResponse> GetUserAlbumByIdsAsync(string id);
        public Task<UsersDtoTodosResponse> GetUserTodosByIdsAsync(string id);
        public Task<UsersDtoPostsResponse> GetUserPostsByIdsAsync(string id);
    }
}
