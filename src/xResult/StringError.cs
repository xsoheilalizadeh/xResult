﻿using System;

 namespace xResult
{
    public readonly struct StringError : IError, IEquatable<StringError>
    {
        public StringError(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public static implicit operator StringError(string error) => new StringError(error);

        public static implicit operator string(StringError error) => error.Message;

        public override string ToString()
        {
            return Message;
        }

        public void Throw() => throw new Exception(Message);

        public bool Equals(StringError other)
        {
            return string.Equals(Message, other.Message, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj)
        {
            return obj switch
            {
                null => Message == null,
                StringError error => Equals(error),
                string error => Message == error,
                _ => false
            };
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Message);
        }

        public static bool operator ==(StringError left, StringError right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StringError left, StringError right)
        {
            return !left.Equals(right);
        }
    }
}