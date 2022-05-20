using AutoMapper;
using BestOfferings.API.Data;
using BestOfferings.Core.Dtos;
using BestOfferings.Core.ViewModels;
using BestOfferings.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly BestOfferingsDbContext _db;
        private readonly IMapper _mapper;

        public CategoryService(BestOfferingsDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<CategoryViewModel> GetAll(string serachKey)
        {
            var categories = _db.Categories.Include(x => x.Products).Where(x => x.Name.Contains(serachKey) || string.IsNullOrEmpty(serachKey)).ToList();

            return _mapper.Map<List<CategoryViewModel>>(categories);
        }


    

        public async Task<int> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _db.Categories.Add(category);
            _db.SaveChanges();
            return category.Id;
        }

        public async Task<int> Update(UpdateCategoryDto dto)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == dto.Id);
            if (category == null)
            {
                //throw 
            }
            var updatedCategory = _mapper.Map(dto, category);
            _db.Categories.Update(updatedCategory);
            _db.SaveChanges();
            return category.Id;
        }


        public async Task<int> Delete(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                //throw 
            }
            category.IsDelete = true;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return category.Id;
        }

        public async Task<CategoryViewModel> Get(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                //throw 
            }
            var categoryVm = _mapper.Map<CategoryViewModel>(category);
            categoryVm.ProductCount = _db.Products.Count(x => x.CategoryId == category.Id);
            return categoryVm;
        }


    }
}