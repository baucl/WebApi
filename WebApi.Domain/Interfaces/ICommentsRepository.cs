using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Domain.Interfaces
{
    public interface ICommentsRepository
    {
        public Task<OperationResult<List<CommentsDto>>> GetAllCommentsAsync();
        public Task<OperationResult<List<CommentsDto>>> GetCommentsByPostIdAsync(string postId);
    }
}
