using Core.Exceptions;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace WebAPI.Infrastructure
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var responseModel = new ErrorDataResult<string>(exception.Message);
            httpContext.Response.StatusCode = exception switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError,
            };
            await httpContext.Response.WriteAsJsonAsync(responseModel);
            return true;
        }
    }
}
