﻿namespace xResult
{
    public interface IError
    {
        public static readonly IError Default = new StringError("An error has occured!");

        public void Throw();
    }
}