using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Models;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;
using WebApi.Infrastructure.Helpers;

namespace WebApi.Infrastructure.Services.jsonplaceholder
{
    public class PostsRepository: IPostsRepository
    {
        private readonly HttpClient _client;
        public PostsRepository(HttpClient client)
        {
            _client = client;
        }

        private JsonSerializerSettings GetJsonSettings() =>
         new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        public async Task<OperationResult<List<PostsDto>>> GetPostsAsync(string userId = null)
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<PostsDto>>(await _client.GetAsync(userId is null ? "/posts" : $"/posts?userId={userId}")
                .Result
                .EnsureSuccessStatusCode()
                .Content
                .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<PostsDto>>(ex, "Repository.Method[GetPostsAsync]");
            }
        }

        public async Task<OperationResult<PostsDto>> GetPostByNumberAsync(string postId)
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<PostsDto>(await _client.GetAsync($"/posts/{postId}")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<PostsDto>(ex, "Repository.Method[GetPostByNumberAsync]");
            }
        }

        public async Task<OperationResult<List<CommentsDto>>> GetPostCommentsByNumberAsync(string postId)
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<CommentsDto>>(await _client.GetAsync($"/posts/{postId}/comments")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<CommentsDto>>(ex, "Repository.Method[GetPostCommentsByNumberAsync]");
            }
        }

        public async Task<OperationResult<PostsDto>> CreateNewPost(Post request)
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<PostsDto>(await _client.PostAsJsonAsync($"/posts", request)
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<PostsDto>(ex, "Repository.Method[CreateNewPost]");
            }
        }

        public async Task<OperationResult<PostsDto>> UpdatePost(Post request)
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<PostsDto>(await _client.PutAsJsonAsync($"/posts/{request.id}", request)
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<PostsDto>(ex, "Repository.Method[UpdatePost]");
            }
        }

        public async Task<OperationResult<PostsDto>> UpdateResourcePost(dynamic request, string id)
        {
            try
            {
        
                object obj = JsonConvert.DeserializeObject<object>(JsonConvert.SerializeObject(request));
                return OperationResult.Create(JsonConvert.DeserializeObject<PostsDto>(await _client.PatchAsJsonAsync($"/posts/{id}", obj)
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<PostsDto>(ex, "Repository.Method[UpdateResourcePost]");
            }
        }

        public async Task<OperationResult<object>> DeletePost(string id)
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<object>(await _client.DeleteAsync($"/posts/{id}")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<object>(ex, "Repository.Method[DeletePost]");
            }
        }
    }
}
