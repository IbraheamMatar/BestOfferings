using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.Core.ViewModels
{
   public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }

        public List<ProductViewModel> Products { get; set; }

    }
}
