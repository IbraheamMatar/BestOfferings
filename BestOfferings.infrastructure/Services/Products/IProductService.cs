using BestOfferings.Core.Dtos;
using BestOfferings.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services.Products
{
    public interface IProductService
    {
        //  Task<List<ProductViewModel>> GetAllAPI(string serachKey);
        List<ProductViewModel> GetAllAPI(string serachKey);
        Task<ResponseDto> GetAll(Pagination pagination, Query query); // Web GetAllData
        Task<int> Create(CreateProductDto dto);
        Task<int> Update(UpdateProductDto dto);
        //Task<int> Delete(int id);
        Task<int> Delete(int Id);
        Task<UpdateProductDto> Get(int Id);
        List<ProductPureViewModel> LatestOffers_Products();
    }
}
