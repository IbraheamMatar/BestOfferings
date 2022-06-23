using BestOfferings.Core.Constant;
using BestOfferings.Core.Dtos;
using BestOfferings.infrastructure.Services.Categories;
using BestOfferings.infrastructure.Services.Markets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestOfferings.Web.Controllers
{
    public class MarketController : Controller
    {

        private readonly IMarketService _marketService;
        private readonly ICategoryService _categoryService;


        public MarketController(IMarketService marketService , ICategoryService categoryService)
        {
            _marketService = marketService;
            _categoryService = categoryService;

        }


        // GET: MarketController
        public ActionResult Index()
        {
            return View();
        }

       public async Task<JsonResult> GetAllMarket(Pagination pagination, Query query)
        {
            var result = await _marketService.GetAllMarket(pagination, query);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["category"] = new SelectList(await _categoryService.GetCategoryName(), "Id", "Name");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateMarketDto dto)  
        {
            if (ModelState.IsValid)
            {
                ViewData["category"] = new SelectList(await _categoryService.GetCategoryName(), "Id", "Name");
                await _marketService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var market = await _marketService.Get(id);
            return View(market);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMarketDto dto)
        {
            if (ModelState.IsValid)
            {
                await _marketService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _marketService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }






       

    }
}
