using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Interfaces;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Services
{
    public class TodoService: ITodoService
    {
        private readonly ITodosRepository _todoRepository;
        public TodoService(ITodosRepository todosRepository)
        {
            _todoRepository = todosRepository;
        }

        public async Task<TodosDtoResponse> GetAllTodosAsync()
        {
            var result = await _todoRepository.GetAllTodosAsync();
            if (result.Success)
            {
                return new TodosDtoResponse
                {
                    Value = result.Value,
                    Success = true,
                    ErrorList = null
                };
            }
            else
            {
                return new TodosDtoResponse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
            }
        }
    }
}
