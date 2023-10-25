using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FullStackAuth_WebAPI.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class WishListedGame
    {
        [Key]
        public int Id { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string Thumbnail { get; set; }
        public string CheapestCurrentDealId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
