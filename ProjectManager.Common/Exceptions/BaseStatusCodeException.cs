using System;

namespace ProjectManager.Common.Exceptions
{
    public abstract class BaseStatusCodeException : Exception
    {
        public abstract int StatusCode { get; }

        public string ErrorCode { get; }
        public string ErrorMessage { get; }

        public BaseStatusCodeException(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}