using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Interfaces
{
    public interface ICommentService
    {
        public Task<CommentsDtoResopnse> GetAllCommentsAsync();
        public Task<CommentsDtoResopnse> GetCommentsByPostIdAsync(string postId);
    }
}
