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
    public class UsersRepository: IUsersRepository
    {
        private readonly HttpClient _client;
        public UsersRepository(HttpClient client)
        {
            _client = client;
        }
        private JsonSerializerSettings GetJsonSettings() =>
            new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        public async Task<OperationResult<List<UsersDto>>> GetAllUsersAsync()
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<UsersDto>>(await _client.GetAsync("/users")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<UsersDto>>(ex, "Repository.Method[GetAllUsersAsync]");
            }
        }

        public async Task<OperationResult<List<AlbumsDto>>> GetUserAlbumByIdsAsync(string id)
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<AlbumsDto>>(await _client.GetAsync($"/users/{id}/albums")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<AlbumsDto>>(ex, "Repository.Method[GetUserAlbumByIdsAsync]");
            }
        }

        public async Task<OperationResult<List<TodosDto>>> GetUserTodosByIdsAsync(string id)
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<TodosDto>>(await _client.GetAsync($"/users/{id}/todos")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<TodosDto>>(ex, "Repository.Method[GetUserTodosByIdsAsync]");
            }
        }

        public async Task<OperationResult<List<PostsDto>>> GetUserPostsByIdsAsync(string id)
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<PostsDto>>(await _client.GetAsync($"/users/{id}/posts")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<PostsDto>>(ex, "Repository.Method[GetUserPostsByIdsAsync]");
            }
        }

    }
}
