using BestOfferings.Core.Dtos;
using BestOfferings.infrastructure.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestOfferings.API.Controllers
{
    [AllowAnonymous]

    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult GetAPI(string serachkey)
        {
            var categories = _categoryService.GetAPI(serachkey);
            return Ok(categories);
        }


        [HttpGet]
        public ActionResult GetAllCategories(string serachKey)
        {
            var categories = _categoryService.GetAllCategories(serachKey);
            return Ok(categories);
        }


        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryDto dto)
        {
            var savedId = _categoryService.Create(dto);
            return Ok(GetResponse(savedId));
        }



        [HttpPut]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            var savedId = _categoryService.Update(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedId = _categoryService.Delete(id);
            return Ok(GetResponse(deletedId));
        }

    }
}