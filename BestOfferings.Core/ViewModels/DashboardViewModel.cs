using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.Core.ViewModels
{
    public class DashboardViewModel
    {
        public int NumberOfUsers { get; set; }
        public int NumberOfProduct { get; set; }
        public int NumberOfMarket { get; set; }
        public int NumberOfCategory { get; set; }
    }
}