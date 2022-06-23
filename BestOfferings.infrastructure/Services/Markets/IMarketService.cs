using BestOfferings.Core.Dtos;
using BestOfferings.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services.Markets
{
    public interface IMarketService
    {
        //Task<List<MarketViewModel>> GetAll(string serachKey);
        List<MarketViewModel> GetAll(string serachKey);

        Task<ResponseDto> GetAllMarket(Pagination pagination, Query query);

         Task<int> Create(CreateMarketDto dto);

        Task<int> Update(UpdateMarketDto dto);
        // Task<int> Delete(int id);
        Task<int> Delete(int Id);
        Task<List<MarketPureViewModel>> GetMarketName();


        Task<List<MarketViewModel>> NearMe(string userId);
        //Task<MarketViewModel> Get(int id);
        Task<UpdateMarketDto> Get(int Id);


    }
}
