using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListDtoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WishListDtoController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<GameDetailsDto>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GameDetailsDto>/5
        [HttpGet("{gameId}"), Authorize]
        public IActionResult Get(int gameId)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                var wishListedGames = _context.WishListedGames.Where(w => w.GameId == gameId && w.UserId == userId).ToList();
                bool isWishlisted = false;
                if (wishListedGames.Count != 0)
                {
                    isWishlisted = true;
                }
                var Wishlist = new WishListDto
                {
                    UserId = userId,
                    WishListedGames = _context.WishListedGames.Where(w => w.GameId == gameId && w.UserId == userId).Select(w => new GameDetailsDto
                    {
                        GameId = w.GameId,
                        GameName = w.GameName,
                        Thumbnail = w.Thumbnail,
                        CheapestCurrentDeal = w.CheapestCurrentDealId
                    }).ToList()
                };
                return StatusCode(200, Wishlist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<GameDetailsDto>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameDetailsDto>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameDetailsDto>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
