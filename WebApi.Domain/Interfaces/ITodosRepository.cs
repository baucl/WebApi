using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Domain.Interfaces
{
    public interface ITodosRepository
    {
        public Task<OperationResult<List<TodosDto>>> GetAllTodosAsync();
    }
}
