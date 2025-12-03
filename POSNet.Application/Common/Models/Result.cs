using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSNet.Application.Common.Models
{
    public class Result<T>
    {
        public bool Success { get; init; }
        public T? Value { get; init; }
        public string? ErrorCode { get; init; }
        public List<string> Errors { get; init; } = new();

        public static Result<T> OK(T value)
        {
            return new Result<T>
            {
                Success = true,
                Value = value
            };
        }

        public static Result<T> Fail(string error, string errorCode = "GENERAL_ERROR")
        {
            return new Result<T>
            {
                Success = false,
                ErrorCode = errorCode,
                Errors = new List<string> { error }
            };
        }


        public static Result<T> Fail(List<string> errors, string errorCode = "GENERAL_ERROR")
        {
            return new Result<T>
            {
                Success = false,
                ErrorCode = errorCode,
                Errors = errors
            };
        }


    }
}
