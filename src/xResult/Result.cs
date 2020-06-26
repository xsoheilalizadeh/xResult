using System;
using System.Collections.Generic;
using System.Diagnostics;
using static xResult.Result;

namespace xResult
{
    [DebuggerDisplay("{DebuggerToString(),nq}")]
    public readonly struct Result : IEquatable<Result>
    {
        private Result(EmptyValue value, StringError error)
        {
            _result = new Result<EmptyValue, StringError>(value, error);
        }    
    
        private readonly Result<EmptyValue, StringError> _result;

        public EmptyValue Value => _result.Value;

        public StringError Error => _result.Error;

        public bool Succeeded => _result.Succeeded;

        public static Result<TValue, StringError> Ok<TValue>(TValue value) => new Result<TValue, StringError>(value);
        public static Result<EmptyValue, StringError> Ok() => new Result<EmptyValue, StringError>();

        public static Result<EmptyValue, TError> Fail<TError>(TError error) where TError : IError =>
            new Result<EmptyValue, TError>(default!, error);

        public static Result<EmptyValue, StringError> Fail(StringError error) =>
            new Result<EmptyValue, StringError>(default, error);

        public static implicit operator Result(Result<EmptyValue, StringError> result) =>
            new Result(result.Value, result.Error);

        public bool Equals(Result other)
        {
            return other.Error == Error;
        }

        public override bool Equals(object? obj)
        {
            return obj is Result other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _result.GetHashCode();
        }

        public static bool operator ==(Result left, Result right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Result left, Result right)
        {
            return !left.Equals(right);
        }

        internal string DebuggerToString() => _result.DebuggerToString();
    }

    [DebuggerDisplay("{DebuggerToString(),nq}")]
    public readonly struct Result<TValue> : IEquatable<Result<TValue>>
    {
        public Result(TValue value, StringError error = default) : this()
        {
            _result = new Result<TValue, StringError>(value, error);
        }

        private readonly Result<TValue, StringError> _result;

        public TValue Value => _result.Value;

        public StringError Error => _result.Error;

        public bool Succeeded => _result.Succeeded;

        public static implicit operator Result<TValue>(Result<TValue, StringError> result) =>
            new Result<TValue>(result.Value);

        public static implicit operator Result<TValue>(Result<EmptyValue, StringError> result) =>
            new Result<TValue>(default!, result.Error);

        public bool Equals(Result<TValue> other)
        {
            return _result.Equals(other._result);
        }

        public override bool Equals(object? obj)
        {
            return obj is Result<TValue> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _result.GetHashCode();
        }

        public static bool operator ==(Result<TValue> left, Result<TValue> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Result<TValue> left, Result<TValue> right)
        {
            return !left.Equals(right);
        }

        internal string DebuggerToString() => _result.DebuggerToString();
    }

    [DebuggerDisplay("{DebuggerToString(),nq}")]
    public readonly struct Result<TValue, TError> : IEquatable<Result<TValue, TError>> where TError : IError
    {
        public Result(TValue value, TError error = default)
        {
            Value = value;
            Error = error;
        }

        public TValue Value { get; }

        public TError Error { get; }

        public bool Succeeded => Error switch
        {
            null => true,
            ValueType valueType => valueType.Equals(default),
            _ => false
        };

        public static implicit operator Result<TValue, TError>(Result<EmptyValue, TError> result) =>
            new Result<TValue, TError>(default!, result.Error);

        public bool Equals(Result<TValue, TError> other)
        {
            return EqualityComparer<TValue>.Default.Equals(Value, other.Value) &&
                   EqualityComparer<TError>.Default.Equals(Error, other.Error);
        }

        public override bool Equals(object? obj)
        {
            return obj is Result<TValue, TError> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Error);
        }

        public static bool operator ==(Result<TValue, TError> left, Result<TValue, TError> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Result<TValue, TError> left, Result<TValue, TError> right)
        {
            return !left.Equals(right);
        }


        internal string DebuggerToString()
        {
            return $"Succeeded: {Succeeded}{(!Succeeded ? $", Error: {Error.ToString()}" : string.Empty)}";
        }
    }
}