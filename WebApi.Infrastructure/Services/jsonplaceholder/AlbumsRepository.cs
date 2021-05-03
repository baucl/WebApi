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
    public class AlbumsRepository: IAlbumsRepository
    {
        private readonly HttpClient _client;
        public AlbumsRepository(HttpClient client)
        {
            _client = client;
        }

        private JsonSerializerSettings GetJsonSettings() =>
          new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        public async Task<OperationResult<List<AlbumsDto>>> GetAllAlbumsAsync()
        {
            try
            {
                return OperationResult.Create(JsonConvert.DeserializeObject<List<AlbumsDto>> (await _client.GetAsync("/albums")
                    .Result
                    .EnsureSuccessStatusCode()
                    .Content
                    .ReadAsStringAsync(), GetJsonSettings()));
            }
            catch (Exception ex)
            {
                return OperationResult.CreateError<List<AlbumsDto>>(ex, "Repository.Method[GetAllAlbumsAsync]");
            }
        }
    }
}
