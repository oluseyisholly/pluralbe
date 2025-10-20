using System.ComponentModel.DataAnnotations;

namespace EcommerceWebApi.Dto
{
    public class PaginationQuery
    {
        public int PageNumber { get; set; } = 1; // default to page 1

        public int PageSize { get; set; } = 10; // default to 10 items per page
    }

    public class BaseDto
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
