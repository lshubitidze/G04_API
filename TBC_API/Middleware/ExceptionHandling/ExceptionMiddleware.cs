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

                switch (error.InnerException)
                {
                    case DuplicateWaitObjectException:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;
                    case ArgumentException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                await response.WriteAsync(JsonSerializer.Serialize(new { code = response.StatusCode, message = error.InnerException?.Message }));
            }
        }
    }
}
