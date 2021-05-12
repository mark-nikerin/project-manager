using Microsoft.AspNetCore.Http;

namespace ProjectManager.Common.Exceptions
{
    public sealed class BadRequestException : BaseStatusCodeException
    {
        public override int StatusCode => StatusCodes.Status400BadRequest;

        public BadRequestException(string errorCode, string errorMessage)
            : base(errorCode, errorMessage)
        {
        }
    }
}