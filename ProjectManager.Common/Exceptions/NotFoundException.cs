using Microsoft.AspNetCore.Http;

namespace ProjectManager.Common.Exceptions
{
    public sealed class NotFoundException : BaseStatusCodeException
    {
        public override int StatusCode => StatusCodes.Status404NotFound;

        public NotFoundException(string errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
        }
    }
}