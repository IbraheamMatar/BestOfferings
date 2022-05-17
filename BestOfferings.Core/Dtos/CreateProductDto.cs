using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.Core.Dtos
{
  public  class CreateProductDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public float Price { get; set; }
        public float? DiscountValue { get; set; }

        public int MarketId { get; set; }
      //  public CreateMarketDto Market { get; set; }
        public int CategoryId { get; set; }
       // public CreateCategoryDto Category { get; set; }

    }
}
