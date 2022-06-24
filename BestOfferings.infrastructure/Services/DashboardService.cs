using BestOfferings.API.Data;
using BestOfferings.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly BestOfferingsDbContext _db;
        public DashboardService(BestOfferingsDbContext db)
        {
            _db = db;
        }


        public async Task<DashboardViewModel> GetData()
        {
            var data = new DashboardViewModel();
            data.NumberOfUsers = await _db.Users.CountAsync(x => !x.IsDelete);
            data.NumberOfProduct = await _db.Products.CountAsync(x => !x.IsDelete);
            data.NumberOfMarket = await _db.Markets.CountAsync(x => !x.IsDelete);
            data.NumberOfCategory = await _db.Categories.CountAsync(x => !x.IsDelete);
            return data;
        }


        public async Task<List<PieChartViewModel>> GetContentTypeChart()
        {

            var data = new List<PieChartViewModel>();
            data.Add(new PieChartViewModel()   //                

            {
                Key = "Resturant",
                Value = await _db.Products.CountAsync(x => x.CategoryId == 1 && !x.IsDelete),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Mall",
                Value = await _db.Products.CountAsync(x => x.CategoryId == 2 && !x.IsDelete),
                color = GenrateColor()
            });

            return data;
        }



        public async Task<List<PieChartViewModel>> GetProductByMonthChart()
        {

            var data = new List<PieChartViewModel>();
            data.Add(new PieChartViewModel()
            {
                Key = "Jan",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 1).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Feb",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 2).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Mar",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 3).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Apr",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 4).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "May",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 5).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Jun",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 6).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Jul",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 7).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Aug",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 8).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Sep",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 9).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Oct",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 10).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Nov",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 11).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Dec",
                Value = _db.Products.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 12).Count(),
                color = GenrateColor()
            });

            return data;
        }

        private string GenrateColor()
        {
            var random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }

    }
}
