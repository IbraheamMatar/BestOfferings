using BestOfferings.Core.Dtos;
using BestOfferings.Data.Models;
using BestOfferings.infrastructure.Services.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestOfferings.API.Controllers
{
    public class ProductController : BaseController

    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public IActionResult GetAll(string searchKey)
        {
            var product = _productService.GetAllAPI(searchKey);
            return Ok(product);

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductDto dto)
        {

            var savedId = await _productService.Create(dto);

            return Ok(GetResponse(savedId));

        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProductDto dto)
        {
            var savedId = await _productService.Update(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var savedId = await _productService.Delete(id);
            return Ok(GetResponse(savedId));
        }




    }
}
