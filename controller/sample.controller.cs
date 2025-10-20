using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        // GET: api/sample
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = new[]
            {
                new { Id = 1, Name = "Item One" },
                new { Id = 2, Name = "Item Two" },
                new { Id = 3, Name = "Item Three" },
            };

            return Ok(data);
        }

        // GET: api/sample/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = new { Id = id, Name = $"Item {id}" };

            return Ok(item);
        }

        // POST: api/sample
        [HttpPost]
        public IActionResult Create([FromBody] SampleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = new { Id = 100, Name = dto.Name };
            return CreatedAtAction(nameof(GetById), new { id = 100 }, created);
        }
    }

    // Sample Data Transfer Object (DTO)
    public class SampleDto
    {
        public string Name { get; set; } = default!;
    }
}
