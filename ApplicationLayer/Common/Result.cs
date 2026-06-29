using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Common
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public Error? Error { get; set; }
        protected Result(bool isSuccess,Error? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
        public static Result Success() => new Result(true, null);
        public static Result Failure(Error error) => new(false, error);
    }
    public sealed record Error(int Code, string Discription);

    public sealed class Result<T> : Result
    {
        public T? Value { get; }
        private Result(T value) : base(true, null)
        {
            Value = value;
        }
        private Result(Error error):base(false,error)
        {
            
        }

        public static Result<T> Success(T value)
        {
            return new(value);
        }
        public static Result<T> Failure(Error error)
        {
            return new(error);
        }
    }
}
