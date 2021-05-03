using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Interfaces;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentsRepository _commetRepository;
        public CommentService(ICommentsRepository commentsRepository)
        {
            _commetRepository = commentsRepository;
        }

        public async Task<CommentsDtoResopnse> GetAllCommentsAsync()
        {
            var result = await _commetRepository.GetAllCommentsAsync();

            if (result.Success)
            {
                return new CommentsDtoResopnse
                {
                    Value = result.Value,
                    Success = true,
                    ErrorList = null
                };
            }
            else
            {
                return new CommentsDtoResopnse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
            }
        }

        public async Task<CommentsDtoResopnse> GetCommentsByPostIdAsync(string postId)
        {
            var result = await _commetRepository.GetCommentsByPostIdAsync(postId);
            if (result.Success)
            {
                return new CommentsDtoResopnse
                {
                    Value = result.Value,
                    Success = true,
                    ErrorList = null
                };
            }
            else
            {
                return new CommentsDtoResopnse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
            }
        }
    }
}
