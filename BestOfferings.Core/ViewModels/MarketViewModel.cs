﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.Core.ViewModels
{
   public class MarketViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Phone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Address { get; set; }

      public List<ProductPureViewModel> Products { get; set; }



    }
}
