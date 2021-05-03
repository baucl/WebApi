using System;
using System.Collections.Generic;

namespace WebApi.Domain.Views.Common
{
    public class Response
    {
        public bool Success { get; set; }
        public List<Error> ErrorList { get; set; }
    }
}
