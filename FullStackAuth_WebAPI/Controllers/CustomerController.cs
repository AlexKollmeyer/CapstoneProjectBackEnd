using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet, Authorize(Policy = "AdminOnly")]
        public IActionResult Get()
        {
            var customerIds = _context.UserRoles
             .Where(ur => ur.RoleId == "c095fdf4-92cf-477c-8627-61e5f7787b05")
             .Select(ur => ur.UserId)
             .ToList();

            var customers = _context.Users
                .Where(u => customerIds.Contains(u.Id))
                .ToList();
            return StatusCode(200, customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
