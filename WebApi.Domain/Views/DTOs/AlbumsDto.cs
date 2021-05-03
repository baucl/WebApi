using System;
using System.Collections.Generic;
using WebApi.Domain.Views.Common;

namespace WebApi.Domain.Views.DTOs
{
    public class AlbumsDto
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
    }

    public class AlbumsDtoResponse : Response
    {
        public List<AlbumsDto> Value { get; set; }
    }
}
