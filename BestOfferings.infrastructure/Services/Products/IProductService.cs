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
        Task<List<ProductViewModel>> GetAllAPI(string serachKey);
        Task<int> Create(CreateProductDto dto);
        Task<int> Update(UpdateProductDto dto);
        Task<int> Delete(int id);
    }
}
