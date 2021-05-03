using System;
using System.Collections.Generic;
using WebApi.Domain.Views.Common;

namespace WebApi.Domain.Views.DTOs
{
    public class TodosDto
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool? completed { get; set; }
    }

    public class TodosDtoResponse: Response
    {
        public List<TodosDto> Value { get; set; }
    }
}
