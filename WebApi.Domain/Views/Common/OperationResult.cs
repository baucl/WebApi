using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Domain.Views.Common
{

    public class OperationResult
    {
        public bool Success { get; set; }
        public List<Error> ErrorList { get; set; }
        protected OperationResult(bool success)
        {
            Success = success;
        }
        protected OperationResult(Error error)
        {
            ErrorList = new List<Error> { error };
        }

        protected OperationResult(List<Error> errorList)
        {
            ErrorList = errorList ?? new List<Error>();
        }
         //Listado de errores, error y exepciones
        public static OperationResult CreateError(List<Error> errorList)
            => new OperationResult(errorList);

        public static OperationResult CreateError(Error error)
            => new OperationResult(new List<Error> { error });

        public static OperationResult<R> CreateError<R>(OperationResult result)
            => new OperationResult<R>(result.ErrorList);

        public static OperationResult CreateError(Exception exception, string errorCode, string errorMessage = null)
        {
            var exceptionList = exception.GetType() == typeof(AggregateException)
                ? ((AggregateException)exception).FilterValidExceptions()
                : exception.GetAllInnerExceptions();

            var errorList = new List<Error>();
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                errorList.Add(new Error(errorCode, errorMessage));
            }

            errorList.AddRange(exceptionList.Select(x => new Error(errorCode)));

            return CreateError(errorList);
        }

        public static OperationResult<R> CreateError<R>(Exception exception, string errorCode, string errorMessage = null)
        {
            return CreateError<R>(CreateError(exception, errorCode, errorMessage));
        }

        //Creacion y/o respuesta correcta 
        public static OperationResult Create()
            => new OperationResult(true);

        public static OperationResult<R> Create<R>(R value)
            => new OperationResult<R>(true, value);

    }

    //Valores de retorno
    public class OperationResult<T> : OperationResult
    {
        public T Value { get; set; }
        internal OperationResult(T result) : this(true, result) { }
        internal OperationResult(Error error) : base(error) { }
        internal OperationResult(List<Error> errorList) : base(errorList) { }
        internal OperationResult(bool success) : base(success) { }
        internal OperationResult(bool success, T value) : base(success)
        {
            Value = value;
        }
    }
}
