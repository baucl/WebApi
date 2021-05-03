using System;
using System.Collections.Generic;
using WebApi.Domain.Views.Common;

namespace WebApi.Domain.Views.DTOs
{
    public class CommentsDto
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }

    public class CommentsDtoResopnse : Response
    {
        public List<CommentsDto> Value { get; set; }
    }
}
