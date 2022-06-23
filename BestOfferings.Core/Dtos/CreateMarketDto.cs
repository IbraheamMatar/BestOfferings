using BestOfferings.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.Core.Dtos
{
   public class CreateMarketDto
    {
        [Required]
        public string Name { get; set; }
        public IFormFile LogoUrl { get; set; } // updated Data Type Replace string to IformFile
        [Required]
        public string Phone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Address { get; set; }

        public int CategoryId { get; set; }   // create catg mahmoud 


        // public List<IFormFile> Products { get; set; }

        //public List<ProductViewModel> Products { get; set; }   // Last Change


    }
}
