using System;
using System.Collections.Generic;
using WebApi.Domain.Views.Common;

namespace WebApi.Domain.Views.DTOs
{
    public class PhotosDto
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }

    public class PhotosDtoResponse: Response
    {
        public List<PhotosDto> Value { get; set; }
    }
}
