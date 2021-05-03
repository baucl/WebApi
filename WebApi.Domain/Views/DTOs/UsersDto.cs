using System;
using System.Collections.Generic;
using WebApi.Domain.Views.Common;

namespace WebApi.Domain.Views.DTOs
{
    public class UsersDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public AddressDto address { get; set; }
    }

    public class UsersDtoResponse: Response
    {
        public List<UsersDto> Value { get; set; }
    }

    public class UsersDtoAlbumsResponse : Response
    {
        public List<AlbumsDto> Value { get; set; }
    }

    public class UsersDtoTodosResponse : Response
    {
        public List<TodosDto> Value { get; set; }
    }

    public class UsersDtoPostsResponse : Response
    {
        public List<PostsDto> Value { get; set; }
    }
}
