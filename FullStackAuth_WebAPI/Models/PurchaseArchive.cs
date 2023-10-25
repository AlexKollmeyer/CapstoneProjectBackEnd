using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class PurchaseArchive
    {
        [Key]
        public int Id { get; set; }
        public string PurchasedGameTitle { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double PurchaseAmount { get; set; }
        public double Savings { get; set; }
        public double OriginalPrice { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
