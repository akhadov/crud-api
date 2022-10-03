using DemoWeb.Api.Exceptions;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace DemoWeb.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (StatusCodeException exception)
            {
                await HandleAsync(exception, httpContext);
            }
            catch (Exception error)
            {

            }
            
        }
        public async Task HandleAsync(StatusCodeException statusCodeException, HttpContext httpContext)
        {
            httpContext.Response.StatusCode
        }
    }
}
