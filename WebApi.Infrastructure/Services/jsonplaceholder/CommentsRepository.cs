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
    public class CommentsRepository: ICommentsRepository
    {
        private readonly HttpClient _client;
        public CommentsRepository(HttpClient client)
        {
            _client = client;
        }

        private JsonSerializerSettings GetJsonSettings() =>
          new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        public async Task<OperationResult<List<CommentsDto>>> GetAllCommentsAsync()
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<CommentsDto>>(await _client.GetAsync("/comments")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<CommentsDto>>(ex, "Repository.Method[GetAllCommentsAsync]");
            }
        }

        public async Task<OperationResult<List<CommentsDto>>> GetCommentsByPostIdAsync(string postId)
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<CommentsDto>>(await _client.GetAsync($"/comments?postId={postId}")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<CommentsDto>>(ex, "Repository.Method[GetCommentsByPostIdAsync]");
            }
        }
    }
}
