using System;
namespace WebApi.Domain.Models.Commons
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
    }
}
