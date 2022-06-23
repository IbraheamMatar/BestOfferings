using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.Core.ViewModels
{
   public class ProductViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public float? DiscountValue { get; set; }

        public ProdMrktVM Market{ get; set; }


        public CategoryViewModel Category { get; set; }






    }
}
