using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using FullStackAuth_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListedGameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WishListedGameController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<WishListedController>
        [HttpGet("customerwishlist/{id}"), Authorize(Policy = "AdminOnly")]
        public IActionResult GetCustomerWishList(string id)
        {
            try
            {
                var wishListeds = _context.WishListedGames.Where(c => c.UserId.Equals(id));

                return StatusCode(200, wishListeds);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        // GET api/<WishListedController>/5
        [HttpGet("mywishlist"), Authorize]
        public IActionResult Get(string id)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                var wishListeds = _context.WishListedGames.Where(c => c.UserId.Equals(userId));
                return StatusCode(200, wishListeds);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<WishListedController>
        [HttpPost]
        public IActionResult Post([FromBody] WishListedGame data)
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


                _context.WishListedGames.Add(data);
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

        // PUT api/<WishListedController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WishListedGame wishListedGame)
        {
            var wishListedGameToUpdate = _context.WishListedGames.Find(id);
            if (wishListedGameToUpdate == null)
            {
                return NotFound();
            }
            _context.SaveChanges();
            return Ok(wishListedGame);
        }
            // DELETE api/<WishListedController>/5
            [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var wishListedGameToRemove = _context.WishListedGames.FirstOrDefault(m => m.Id == id);
            if (wishListedGameToRemove == null)
                return NotFound();
            _context.WishListedGames.Remove(wishListedGameToRemove);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
