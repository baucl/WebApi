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
    public class PhotosRepository: IPhotosRepository
    {
        private readonly HttpClient _client;
        public PhotosRepository(HttpClient client)
        {
            _client = client;
        }
        private JsonSerializerSettings GetJsonSettings() =>
          new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        public async Task<OperationResult<List<PhotosDto>>> GetAllPhotosAsync()
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<PhotosDto>>(await _client.GetAsync("/photos")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<PhotosDto>>(ex, "Repository.Method[GetAllCommentsAsync]");
            }
        }
    }
}
