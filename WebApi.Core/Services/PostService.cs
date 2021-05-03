using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using WebApi.Core.Interfaces;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Models;
using WebApi.Domain.Views.Common;
using WebApi.Domain.Views.DTOs;

namespace WebApi.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostsRepository _postsRepository;
        public PostService(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public async Task<PostsDtoResponse> GetAllPostAsync(string userId)
        {
            var result = await _postsRepository.GetPostsAsync(userId);
            return result.Success
            ?
                new PostsDtoResponse
                {
                    Value = result.Value,
                    Success = true,
                    ErrorList = null
                }
                :
                new PostsDtoResponse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
        }

        public async Task<PostsDtoResponse> GetPostByNumberAsync(string postId)
        {
            var result = await _postsRepository.GetPostByNumberAsync(postId);
            var responseDto = new PostsDtoResponse();
            if (result.Success)
            {
                responseDto.Value = new List<PostsDto>
                {
                    new PostsDto
                    {
                        body = result.Value.body,
                        id = result.Value.id,
                        title = result.Value.title,
                        userId = result.Value.userId,
                    }
                };
                responseDto.Success = true;
                responseDto.ErrorList = null;
            }
            else
            {
                responseDto.Value = null;
                responseDto.Success = false;
                responseDto.ErrorList = result.ErrorList;
            }
            return responseDto;
        }

        public async Task<CommentsDtoResopnse> GetPostCommentsByNumberAsync(string postId)
        {
            var result = await _postsRepository.GetPostCommentsByNumberAsync(postId);
            return result.Success
            ?
                 new CommentsDtoResopnse
                 {
                     Value = result.Value,
                     Success = true,
                     ErrorList = null
                 }
                :
                 new CommentsDtoResopnse
                 {
                     Value = null,
                     Success = false,
                     ErrorList = result.ErrorList
                 };
        }

        public async Task<PostsDtoResponse> GetPostByUserIdAsync(string userId)
        {
            var result = await _postsRepository.GetPostsAsync(userId);
            return result.Success
            ?
                 new PostsDtoResponse
                 {
                     Value = result.Value,
                     Success = true,
                     ErrorList = null
                 }
                :
                 new PostsDtoResponse
                 {
                     Value = null,
                     Success = false,
                     ErrorList = result.ErrorList
                 };
        }

        public async Task<PostsDtoCreateResponse> CreateNewPost(PostsDtoRequest request)
        {
            var result = await _postsRepository.CreateNewPost(new Post
            {
                title = request.title,
                body = request.body,
                userId = request.userId
            });

            return result.Success
                ?
                 new PostsDtoCreateResponse
                 {
                     Value = new PostsDto
                     {
                         id = result.Value.id,
                         title = result.Value.title,
                         body = result.Value.body,
                         userId = result.Value.userId
                     },
                     Success = true,
                     ErrorList = null
                 }
                 :
                new PostsDtoCreateResponse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
        }

        public async Task<PostsDtoUpdateResponse> UpdatePost(PostsUpdateDtoRequest request)
        {
            var result = await _postsRepository.UpdatePost(new Post
            {
                id = request.userId,
                title = request.title,
                body = request.body,
                userId = request.userId
            });

            return result.Success
                ? new PostsDtoUpdateResponse
                {
                    Value = new PostsDto
                    {
                        id = result.Value.id,
                        title = result.Value.title,
                        body = result.Value.body,
                        userId = result.Value.userId
                    },
                    Success = true,
                    ErrorList = null
                }
                : new PostsDtoUpdateResponse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
            
        }

        public async Task<PostsDtoUpdateResponse> UpdateResourcePost(PostsUpdateResourceDtoRequest request, string id)
        {

            var valuesPatchFields = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(request));
            var infoMapped = new Dictionary<string, dynamic>();

            foreach (var value in valuesPatchFields)
            {
                if (!String.IsNullOrEmpty(value.Value))
                {
                    if (value.Value != "0")
                    {
                        infoMapped.Add(value.Key, value.Value);
                    }
                }
            }

            var result = await _postsRepository.UpdateResourcePost(infoMapped, id);

            return result.Success
                ? new PostsDtoUpdateResponse
                {
                    Value = new PostsDto
                    {
                        id = result.Value.id,
                        title = result.Value.title,
                        body = result.Value.body,
                        userId = result.Value.userId
                    },
                    Success = true,
                    ErrorList = null
                }
                : new PostsDtoUpdateResponse
                {
                    Value = null,
                    Success = false,
                    ErrorList = result.ErrorList
                };
        }

        public async Task<PostsDtoResponse> DeletePost(string id)
        {
            var result = await _postsRepository.DeletePost(id);
            return result.Success
                ?
                new PostsDtoResponse
                {
                    Value = null,
                    Success = true,
                    ErrorList = null
                } :
                new PostsDtoResponse
                {
                     Value = null,
                     Success = false,
                     ErrorList = result.ErrorList
                };
        }
    }
}
