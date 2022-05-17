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
        Task<List<MarketViewModel>> GetAll(string serachKey);

         Task<int> Create(CreateMarketDto dto);

        Task<List<MarketViewModel>> NearMe(string userId);



    }
}
