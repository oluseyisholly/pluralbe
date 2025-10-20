using System.Net;
using System.Text.Json;
using EcommerceWebApi.Exceptions;

namespace EcommerceWebApi.Middleware
{
    public class ErrorHandlingMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlingMiddleware> logger
    )
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;
        public static readonly string contentType = "application/json";

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Proceed to the next middleware
            }
            catch (NotFoundException ex)
            {
                await HandleNotFoundExceptionAsync(context, ex);
            }
            catch (UnprocessibleEntityException ex)
            {
                await HandleUnprocessibleEntityExceptionAsync(context, ex);
            }
            catch (ConflictException ex)
            {
                await HandleConflictExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                StatusCode = statusCode,
                Message = "An unexpected error occurred.",
                Detail = exception.Message, // For dev only; remove in production
            };

            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static Task HandleNotFoundExceptionAsync(HttpContext context, Exception exception)
        {
            return ExceptionAbstract(context, (int)HttpStatusCode.NotFound, exception);
        }

        private static Task HandleUnprocessibleEntityExceptionAsync(
            HttpContext context,
            Exception exception
        )
        {
            return ExceptionAbstract(context, (int)HttpStatusCode.UnprocessableContent, exception);
        }

        private static Task HandleConflictExceptionAsync(HttpContext context, Exception exception)
        {
            return ExceptionAbstract(context, (int)HttpStatusCode.UnprocessableContent, exception);
        }

        private static Task ExceptionAbstract(
            HttpContext context,
            int statusCode,
            Exception exception
        )
        {
            var response = new { StatusCode = statusCode, exception.Message };

            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
