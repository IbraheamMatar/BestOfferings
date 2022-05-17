using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.Data.Models
{
  public  class Market
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        [Required]
        public string Phone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Address { get; set; }

        public List<Product> Products{ get; set; }

        public List<Order> Orders { get; set; }


    }
}
