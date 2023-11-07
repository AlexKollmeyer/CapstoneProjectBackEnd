using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseArchiveController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PurchaseArchiveController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<PurchaseArchiveController>
        [HttpGet("allcustomerpurchases"), Authorize(Policy ="AdminOnly")]
        public IActionResult GetAllPurchases(string id)
        {
            var purchases = _context.PurchaseArchives.ToList();
            return StatusCode(200, purchases);
        }

        // GET api/<PurchaseArchiveController>/5
        [HttpGet("mypurchasearchive"), Authorize]
        public IActionResult Get(string id)
        {
            try
            {
                // Retrieve the authenticated user's ID from the JWT token
                string userId = User.FindFirstValue("id");

 
                var purchaseArchives = _context.PurchaseArchives.Where(c => c.UserId.Equals(userId));


                return StatusCode(200, purchaseArchives);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<PurchaseArchiveController>
        [HttpPost]
        public IActionResult Post([FromBody] PurchaseArchive data)
        {
            try
            {
                // Retrieve the authenticated user's ID from the JWT token
                string userId = User.FindFirstValue("id");


                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }


                data.UserId = userId;


                _context.PurchaseArchives.Add(data);
                if (!ModelState.IsValid)
                {

                    return BadRequest(ModelState);
                }
                _context.SaveChanges();


                return StatusCode(201, data);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<PurchaseArchiveController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PurchaseArchiveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
