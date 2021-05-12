using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectManager.Common.ErrorResponses;
using ProjectManager.Common.Exceptions;

namespace ProjectManager.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BaseStatusCodeException exception)
            {
                var response = new ClientErrorResponse(exception.ErrorCode, exception.ErrorMessage);

                context.HttpContext.Response.StatusCode = exception.StatusCode;
                context.Result = new JsonResult(response);
            }
            else
            {
                var ex = context.Exception;
                var response = new ServerErrorResponse(ErrorResponseCodes.UnhandledException, ex.Message, ex.StackTrace);

                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new JsonResult(response);
            }

            base.OnException(context);
        }
    }
}