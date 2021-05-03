using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Infrastructure.Services.jsonplaceholder
{
    public class TodosRepository: ITodosRepository
    {
        private readonly HttpClient _client;
        public TodosRepository(HttpClient client)
        {
            _client = client;
        }
        private JsonSerializerSettings GetJsonSettings() =>
         new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        public async Task<OperationResult<List<TodosDto>>> GetAllTodosAsync()
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<TodosDto>>(await _client.GetAsync("/todos")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<TodosDto>> (ex, "Repository.Method[GetAllTodosAsync]");
            }
        }
    }
}
