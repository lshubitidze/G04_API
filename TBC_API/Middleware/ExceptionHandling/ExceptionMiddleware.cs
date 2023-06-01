using System.Net;
using System.Text.Json;

namespace TBC_API.Middleware.ExeptionHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error.InnerException switch
                {
                    DuplicateWaitObjectException => (int)HttpStatusCode.Conflict,
                    ArgumentException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError,
                };
                await response.WriteAsync(JsonSerializer.Serialize(new { code = response.StatusCode, message = error.InnerException?.Message }));
            }
        }
    }
}
