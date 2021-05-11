using System;
using ProjectManager.Services.Interfaces.DTO.Base;

namespace ProjectManager.Services.Interfaces
{
    public interface IServiceResult<T, TErrorEnum> where TErrorEnum : Enum
    {
        public T Value { get; set; }

        public ErrorInfo<TErrorEnum> Error { get; set; }
    }
}