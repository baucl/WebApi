using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Models;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Domain.Interfaces
{
    public interface IPostsRepository
    {
        public Task<OperationResult<List<PostsDto>>> GetPostsAsync(string userId);
        public Task<OperationResult<PostsDto>> GetPostByNumberAsync(string postId);
        public Task<OperationResult<List<CommentsDto>>> GetPostCommentsByNumberAsync(string postId);
        public Task<OperationResult<PostsDto>> CreateNewPost(Post request);
        public Task<OperationResult<PostsDto>> UpdatePost(Post request);
        public Task<OperationResult<PostsDto>> UpdateResourcePost(dynamic request, string id);
        public Task<OperationResult<object>> DeletePost(string id);
    }
}
