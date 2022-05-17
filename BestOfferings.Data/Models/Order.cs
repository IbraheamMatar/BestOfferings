using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string CustomerId { get; set; }
        public User Customer { get; set; }
        public int MarketId { get; set; }
        public Market Market { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
