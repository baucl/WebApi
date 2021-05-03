using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Domain.Views.Common;

namespace WebApi.Domain.Views.DTOs
{
    public class PostsDto
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    public class PostsDtoRequest
    {
        [Required(ErrorMessage = "El campo userId es requerido")]
        public int userId { get; set; }
        [Required(ErrorMessage = "El campo title es requerido")]
        public string title { get; set; }
        [Required(ErrorMessage = "El campo body es requerido")]
        public string body { get; set; }
    }

    public class PostsUpdateDtoRequest
    {
        [Required(ErrorMessage = "El campo id es requerido")]
        public int id { get; set; }
        [Required(ErrorMessage = "El campo userId es requerido")]
        public int userId { get; set; }
        [Required(ErrorMessage = "El campo title es requerido")]
        public string title { get; set; }
        [Required(ErrorMessage = "El campo body es requerido")]
        public string body { get; set; }
    }

    public class PostsUpdateResourceDtoRequest
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }


    public class PostsDtoResponse: Response
    {
        public List<PostsDto> Value { get; set; }
    }

    public class PostsDtoCreateResponse : Response
    {
        public PostsDto Value { get; set; }
    }

    public class PostsDtoUpdateResponse : Response
    {
        public PostsDto Value { get; set; }
    }
}
