using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Interfaces
{
    public interface IPostService
    {
        public Task<PostsDtoResponse> GetAllPostAsync(string userId);
        public Task<PostsDtoResponse> GetPostByNumberAsync(string postId);
        public Task<CommentsDtoResopnse> GetPostCommentsByNumberAsync(string postId);
        public Task<PostsDtoCreateResponse> CreateNewPost(PostsDtoRequest request);
        public Task<PostsDtoUpdateResponse> UpdatePost(PostsUpdateDtoRequest request);
        public Task<PostsDtoUpdateResponse> UpdateResourcePost(PostsUpdateResourceDtoRequest request, string id);
        public Task<PostsDtoResponse> DeletePost(string id);
    }
}
