using FoodOrderApplication.ExceptionsHandler;
using System.Net;

namespace FoodOrderApplication.Middleware
{
    public class MiddlewareHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await ExceptionHandler(context, ex);
            }
        }

        public static Task ExceptionHandler(HttpContext context, Exception ex)
        {
            var statuscode = HttpStatusCode.InternalServerError;
            var errorMessage = "This internal server error code: 500";

            if (ex is NotFoundExceptionHandler)
            {
                statuscode = HttpStatusCode.NotFound;
                errorMessage = ex.Message;
            }

            context.Response.StatusCode = (int)statuscode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsJsonAsync(new ErrorMapping((int)statuscode, errorMessage));

        }
    }
}