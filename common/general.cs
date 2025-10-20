namespace EcommerceWebApi.Common.Model
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpiresInMinutes { get; set; }
    }

    public class StandardResponse<T>
    {
        public string Message { get; set; } = "Success";
        public T? Data { get; set; }
    }

    public class PaymentApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
    }

    public class PaginatedResponse<T>(List<T> data, int totalRecords, int pageNumber, int pageSize)
    {
        public int PageNumber { get; set; } = pageNumber;
        public int PageSize { get; set; } = pageSize;
        public int TotalRecords { get; set; } = totalRecords;
        public List<T> Data { get; set; } = data;
    }
}
