using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Domain.Interfaces
{
    public interface IUsersRepository
    {
        public Task<OperationResult<List<UsersDto>>> GetAllUsersAsync();
        public Task<OperationResult<List<AlbumsDto>>> GetUserAlbumByIdsAsync(string id);
        public Task<OperationResult<List<TodosDto>>> GetUserTodosByIdsAsync(string id);
        public Task<OperationResult<List<PostsDto>>> GetUserPostsByIdsAsync(string id);
    }
}
