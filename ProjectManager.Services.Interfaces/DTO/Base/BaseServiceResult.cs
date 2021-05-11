using System;

namespace ProjectManager.Services.Interfaces.DTO.Base
{
    public class BaseServiceResult<T, TErrorEnum> : IServiceResult<T, TErrorEnum> where TErrorEnum : Enum
    {
        public T Value { get; set; }
        public ErrorInfo<TErrorEnum> Error { get; set; }
    }
}