using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Common
{
    public class Result<T>
    {
        public bool IsSucess { get; }
        public string? Error { get; }

        public T Value { get; }

        private Result(bool isSucess, string? error, T value)
        {
            IsSucess = isSucess;
            Error = error;
            Value = value;
        }

        public static Result<T> Success(T value) => new(true, null, value);

        public static Result<T> Failed(string error) => new(false, error, default);
    }
}
