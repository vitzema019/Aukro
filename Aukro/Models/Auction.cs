using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aukro.Models
{
    public class Auction
    {
        public int AuctionId { get; set; }
        public int MinimumPrice { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfEnd { get; set; }
        public int? CreatorId { get; set; }
        public User Creator { get; set; }
        public int? LastUserId { get; set; }
        public User LastUser { get; set; }


    }
}
