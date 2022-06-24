using BestOfferings.infrastructure.Services;
using BestOfferings.infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BestOfferings.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IDashboardService _dashboardService;

        public HomeController(IDashboardService dashboardService, IUserService userService) 
        {
            _dashboardService = dashboardService;
        }







        public async Task<IActionResult> Index()
        {
      
            var data = await _dashboardService.GetData();
            return View(data);
        }

        public async Task<IActionResult> GetContentTypeChartData()
        {
            var data = await _dashboardService.GetContentTypeChart();
            return Ok(data);
        }


        public async Task<IActionResult> GetContentByMonthChartData()
        {
            var data = await _dashboardService.GetProductByMonthChart();
            return Ok(data);
        }




    }
}
