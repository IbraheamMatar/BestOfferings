using AutoMapper;
using BestOfferings.API.Data;
using BestOfferings.Core.Constant;
using BestOfferings.Core.Dtos;
using BestOfferings.Core.ViewModels;
using BestOfferings.Data.Models;
using BestOfferings.infrastructure.Services.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services.Products
{
   public class ProductService : IProductService
    {

        private readonly BestOfferingsDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;


        public ProductService(BestOfferingsDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;

        }

        public async Task<List<ProductViewModel>> GetAllAPI(string serachKey)
        {
            var advertisment =  _db.Products.Include(x => x.Market).Include(x => x.Category.Name).Where(x => x.Name.Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey)).ToList();
            return _mapper.Map<List<ProductViewModel>>(advertisment);

        }


        public async Task<int> Create(CreateProductDto dto)
        {


            var product = _mapper.Map<Product>(dto);
            if (dto.Image != null)
            {
                product.Image = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }
                product.MarketId = dto.MarketId;
                product.CategoryId = dto.CategoryId;
     
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();


            return product.Id;
        }


        public async Task<int> Update(UpdateProductDto dto)
        {

          

            var product = await _db.Products.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            //if (product== null)
            //{
            //   // throw new EntityNotFoundException();
            //}

            var updateProduct = _mapper.Map(dto, product);

            if (dto.Image != null)
            {
                updateProduct.Image = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }

             updateProduct.MarketId = dto.MarketId;
             updateProduct.CategoryId = dto.CategoryId;


            _db.Products.Update(updateProduct);
            await _db.SaveChangesAsync();

            return product.Id;
        }


        public async Task<int> Delete(int id)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (product == null)
            {
               // throw new EntityNotFoundException();
            }
            product.IsDelete = true;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return product.Id;
        }

    }
}
