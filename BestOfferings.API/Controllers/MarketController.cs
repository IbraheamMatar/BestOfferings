using BestOfferings.Core.Dtos;
using BestOfferings.infrastructure.Services.Markets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestOfferings.API.Controllers
{
    public class MarketController : BaseController
    {

        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpGet]
        public ActionResult GetAll(string serachkey)
        {
            var markets = _marketService.GetAll(serachkey);
            return Ok(markets);
        }

        [HttpGet]
        public IActionResult NearMe()
        {
            var category = _marketService.NearMe(UserId);
            return Ok(GetResponse(category));
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateMarketDto dto)  // FormBody to FormForm
        {
            var savedId = _marketService.Create(dto);
            return Ok(GetResponse(savedId));
        }



        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateMarketDto dto)
        {
            var savedId = await _marketService.Update(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var savedId = await _marketService.Delete(id);
            return Ok(GetResponse(savedId));
        }




    }
}
