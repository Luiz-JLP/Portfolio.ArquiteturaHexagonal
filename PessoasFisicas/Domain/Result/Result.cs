﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Result
{
    [ExcludeFromCodeCoverage]
    public class Result<TValue, TError>
    {
        public readonly TValue? Value;
        public readonly TError? Error;

        private readonly bool _isSuccess;

        private Result(TValue? value)
        {
            _isSuccess = true;
            Value = value;
            Error = default;
        }

        private Result(TError? error)
        {
            _isSuccess = false;
            Value = default;
            Error = error;
        }

        public static implicit operator Result<TValue, TError>(TValue? value) => new(value);

        public static implicit operator Result<TValue, TError>(TError? error) => new(error);

        public Result<TValue, TError> Match(Func<TValue, Result<TValue, TError>> success, Func<TError, Result<TValue, TError>> failure)
        {
            return _isSuccess ? success(Value!) : failure(Error!);
        }

        public ObjectResult Match(Func<TValue, ObjectResult> success, Func<TError, ObjectResult> failure)
        {
            return _isSuccess ? success(Value!) : failure(Error!);
        }
    }
}
