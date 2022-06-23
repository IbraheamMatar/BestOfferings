using BestOfferings.Core.Dtos;
using BestOfferings.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services.Categories
{
   public interface ICategoryService
    {
        //  Task<List<CategoryViewModel>> GetAll(string serachKey);
        //List<CategoryViewModel> GetAll(string serachKey); API
        List<CategoryViewModel> GetAPI(string serachKey);

        List<CategoryPureViewModel> GetAllCategories(string serachKey); // pureCatgiroes
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreateCategoryDto dto);
        Task<int> Update(UpdateCategoryDto dto);
        //Task<int> Delete(int id);
        Task<int> Delete(int Id);
        Task<List<CategoryPureViewModel>> GetCategoryName();
        //   Task<CategoryViewModel> Get(int id); API
        //Task<UpdateCategoryDto> Get(int Id);
        Task<UpdateCategoryDto> Get(int Id);
    }
}
