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

        public List<CategoryViewModel> GetAPI(string serachKey)
        {
            var categories = _db.Categories.Include(x => x.Markets).Where(x => x.Name.Contains(serachKey) || string.IsNullOrEmpty(serachKey)).ToList();

            return _mapper.Map<List<CategoryViewModel>>(categories);
        }

        public List<CategoryPureViewModel> GetAllCategories(string serachKey)
        {
            var categories = _db.Categories.Where(x => x.Name.Contains(serachKey) || string.IsNullOrEmpty(serachKey)).ToList();

            return _mapper.Map<List<CategoryPureViewModel>>(categories);
        }




        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Categories.Where(x => !x.IsDelete && (x.Name.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var categories = _mapper.Map<List<CategoryViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = categories,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }





        public async Task<int> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _db.Categories.Add(category);
            _db.SaveChanges();
            return category.Id;
        }




        //public async Task<int> Update(UpdateCategoryDto dto)
        //{
        //    var category = _db.Categories.SingleOrDefault(x => x.Id == dto.Id);
        //    if (category == null)
        //    {
        //        //throw 
        //    }
        //    var updatedCategory = _mapper.Map(dto, category);
        //    _db.Categories.Update(updatedCategory);
        //    _db.SaveChanges();
        //    return category.Id;
        //}


        public async Task<int> Update(UpdateCategoryDto dto)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (category == null)
            {
              //  throw new EntityNotFoundException();
            }
            var updatedCategory = _mapper.Map<UpdateCategoryDto, Category>(dto, category);
            _db.Categories.Update(updatedCategory);
            await _db.SaveChangesAsync();
            return updatedCategory.Id;
        }


        //public async Task<UpdateCategoryDto> Get(int Id)
        //{
        //    var category = await _db.Categories.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
        //    if (category == null)
        //    {
        //       // throw new EntityNotFoundException();
        //    }
        //    return _mapper.Map<UpdateCategoryDto>(category);
        //}

        public async Task<UpdateCategoryDto> Get(int Id)
        {
            var category = _db.Categories.Include(x => x.Markets).SingleOrDefault(x => x.Id == Id);
            if (category == null)
            {
                //throw 
            }
            var categoryVm = _mapper.Map<UpdateCategoryDto>(category);


            return categoryVm;
        }



        public async Task<int> Delete(int Id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == Id);
            if (category == null)
            {
                //throw 
            }
            category.IsDelete = true;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return category.Id;
        }

        public async Task<List<CategoryPureViewModel>> GetCategoryName()
        {
            var category = await _db.Categories.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<CategoryPureViewModel>>(category);
        }



        //public async Task<CategoryViewModel> Get(int id)
        //{
        //    var category = _db.Categories.SingleOrDefault(x => x.Id == id);
        //    if (category == null)
        //    {
        //        //throw 
        //    }
        //    var categoryVm = _mapper.Map<CategoryViewModel>(category);
        //    categoryVm.ProductCount = _db.Products.Count(x => x.CategoryId == category.Id);
        //    return categoryVm;
        //}


    }
}