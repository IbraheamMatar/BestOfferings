using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.Data.Models
{
   public class Product : BaseEntity
    {
    
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public float? DiscountValue { get; set; }

        public int MarketId { get; set; }
        public Market Market { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderItem> Orders { get; set; }

    }
}
