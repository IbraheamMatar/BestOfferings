using BestOfferings.Core.Constant;
using BestOfferings.Core.Dtos;
using BestOfferings.infrastructure.Services.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestOfferings.Web.Controllers
{
    public class CategoryController : Controller
    {
     

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetCategoryData(Pagination pagination, Query query)
        {
            var result = await _categoryService.GetAll(pagination, query);
            return Json(result);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _categoryService.Get(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}

