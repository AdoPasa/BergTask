using Application.Common.Exceptions;
using System.Net;

namespace Web.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException error)
            {
                if (context.Response.HasStarted)
                {
                    return;
                }

                if (string.IsNullOrEmpty(error.Message))
                { 
                    context.Response.Redirect($"/Errors/{(int)HttpStatusCode.InternalServerError}");
                }
                else 
                {
                    context.Response.Redirect($"/Errors/{error.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An unhandled error ocurred: {0}", ex.Message);

                context.Response.Redirect($"/Errors/{(int)HttpStatusCode.InternalServerError}");
            }
        }
    }
}