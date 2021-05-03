using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Domain.Views.Common
{
    public class Error
    {
        public string Origin { get; }
        public string Message { get; }
        public string Type { get; }

        public Error(string origin, string message, string type = "TECHNICAL")
        {
            Origin = origin;
            Message = message;
            Type = type;
        }

        public Error(string code) : this(code, "TECHNICAL") {}

        public Error(string code, string message) : this(code, message, "TECHNICAL"){}

        public override string ToString()
        {
            return $"{{ Code: \"{Origin}\", Type: \"{Type}\", Message: \"{Message}\" }}";
        }
    }

    public static class ExceptionExtension
    {
        public static IEnumerable<Exception> FilterValidExceptions(this AggregateException ae)
        {
            var finalList = new List<Exception> { ae };
            var asyncExceptions = ae.Flatten().InnerExceptions.Where(x => x.GetType() != typeof(AggregateException));

            foreach (var item in asyncExceptions)
            {
                var innerExceptionList = GetInnerExceptionList(item);
                finalList.AddRange(innerExceptionList);
            }

            return finalList;
        }

        private static List<Exception> GetInnerExceptionList(Exception ex)
        {
            var innerExceptionList = new List<Exception>();
            Exception currentEx = ex;
            while (currentEx.InnerException != null)
            {
                innerExceptionList.Add(currentEx);
                currentEx = currentEx.InnerException;
            }
            return innerExceptionList;
        }

        public static IEnumerable<Exception> GetAllInnerExceptions(this Exception ex)
        {
            var finalList = new List<Exception>();
            Exception currentEx = ex;
            while (currentEx != null)
            {
                finalList.Add(currentEx);
                currentEx = currentEx.InnerException;
            }
            return finalList;
        }
    }
}
