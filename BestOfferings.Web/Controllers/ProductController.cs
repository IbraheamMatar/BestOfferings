using BestOfferings.Core.Constant;
using BestOfferings.Core.Dtos;
using BestOfferings.infrastructure.Services.Categories;
using BestOfferings.infrastructure.Services.Markets;
using BestOfferings.infrastructure.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestOfferings.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMarketService _marketService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService , IMarketService marketService , ICategoryService categoryService)
        {
            _productService = productService;
            _marketService = marketService;
            _categoryService = categoryService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetProductData(Pagination pagination, Query query)
        {
            var result = await _productService.GetAll(pagination, query);
            return Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["category"] = new SelectList(await _categoryService.GetCategoryName(), "Id", "Name");
            ViewData["market"] = new SelectList(await _marketService.GetMarketName(), "Id", "Name");


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductDto dto)
        {
            if (ModelState.IsValid)
            {
                ViewData["category"] = new SelectList(await _categoryService.GetCategoryName(), "Id", "Name");
                ViewData["market"] = new SelectList(await _marketService.GetMarketName(), "Id", "Name");
                await _productService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var market = await _productService.Get(id);
            ViewData["category"] = new SelectList(await _categoryService.GetCategoryName(), "Id", "Name");
            ViewData["market"] = new SelectList(await _marketService.GetMarketName(), "Id", "Name");
            return View(market);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm]UpdateProductDto dto)
        {
            if (ModelState.IsValid)
            {
              
                await _productService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            ViewData["category"] = new SelectList(await _categoryService.GetCategoryName(), "Id", "Name");
            ViewData["market"] = new SelectList(await _marketService.GetMarketName(), "Id", "Name");

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
