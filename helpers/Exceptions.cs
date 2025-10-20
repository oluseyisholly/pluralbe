namespace EcommerceWebApi.Exceptions
{
    public abstract class AppException(string message, int statusCode = 500) : Exception(message)
    {
        public int StatusCode { get; } = statusCode;
    }

    public class NotFoundException(string message = "Resource not found.")
        : AppException(message, 404) { }

    public class UnprocessibleEntityException(string message = "Unprocessable Entity")
        : AppException(message, 422) { }

    public class ConflictException(string message = "Unprocessable Conflict")
        : AppException(message, 419) { }

    public class TooManyRequestsException(string message = "Too Many Requests")
        : AppException(message, 419) { }

    public class BadRequestException(string message = "Bad request.")
        : AppException(message, 400) { }

    public class UnauthorizedException(string message = "Unauthorized.")
        : AppException(message, 401) { }
}
