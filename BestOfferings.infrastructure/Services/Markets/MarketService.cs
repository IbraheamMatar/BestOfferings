using AutoMapper;
using BestOfferings.API.Data;
using BestOfferings.Core.Constant;
using BestOfferings.Core.Dtos;
using BestOfferings.Core.ViewModels;
using BestOfferings.Data.Models;
using BestOfferings.infrastructure.Extentions;
using BestOfferings.infrastructure.Services.Files;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services.Markets
{
   public class MarketService : IMarketService
    {
        private readonly BestOfferingsDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;


        public MarketService(BestOfferingsDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;

        }



        public List<MarketViewModel> GetAll(string serachKey)
        {
            var markets =  _db.Markets.Include(x => x.Products).Where(x => x.Name.Contains(serachKey) || string.IsNullOrEmpty(serachKey)).ToList(); //Ass Updated
            return _mapper.Map<List<MarketViewModel>>(markets);
        }



        public async Task<ResponseDto> GetAllMarket(Pagination pagination, Query query)
        {
            var queryString = _db.Markets.Include(x => x.Products).Where(x => !x.IsDelete && (x.Name.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var markets = _mapper.Map<List<MarketViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = markets,
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



        public async Task<List<MarketPureViewModel>> GetMarketName()
        {
            var market = await _db.Markets.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<MarketPureViewModel>>(market);
        }


        public async Task<UpdateMarketDto> Get(int Id)
        {
            var market = _db.Markets.Include (x => x.Products).SingleOrDefault(x => x.Id == Id);
            if (market == null)
            {
                //throw 
            }
            var marketVm = _mapper.Map<UpdateMarketDto>(market);


            return marketVm;
        }




        public async Task<int> Create(CreateMarketDto dto)
        {
            var mrket = _mapper.Map<Market>(dto);

            if (dto.LogoUrl != null)
            {
                mrket.LogoUrl = await _fileService.SaveFile(dto.LogoUrl, FolderNames.ImagesFolder);
            }

            await _db.Markets.AddAsync(mrket);
            await _db.SaveChangesAsync();

            return mrket.Id;
        }


        public async Task<int> Update(UpdateMarketDto dto)        // Reviewing
        {



            var market = await _db.Markets.SingleOrDefaultAsync(x => x.Id == dto.Id );
            //if (product== null)
            //{
            //   // throw new EntityNotFoundException();
            //}

            var updateMarket = _mapper.Map(dto, market);

            if (dto.LogoUrl != null)
            {
                updateMarket.LogoUrl = await _fileService.SaveFile(dto.LogoUrl, FolderNames.ImagesFolder);
            }


            _db.Markets.Update(updateMarket);
            await _db.SaveChangesAsync();

            return market.Id;
        }


        public async Task<int> Delete(int Id)
        {
            var market = await _db.Markets.SingleOrDefaultAsync(x => x.Id == Id);   // Reviewing code 
            if (market == null)
            {
                // throw new EntityNotFoundException();
            }
            _db.Markets.Update(market);
            await _db.SaveChangesAsync();
            return market.Id;
        }




        //public async Task<int> Create(CreateMarketDto dto)
        //{
        //    var mrket = _mapper.Map<Market>(dto);

        //    if (dto.LogoUrl != null)
        //    {
        //        mrket.LogoUrl = await _fileService.SaveFile(dto.LogoUrl, FolderNames.ImagesFolder);
        //    }

        //    await _db.Markets.AddAsync(mrket);
        //    await _db.SaveChangesAsync();
        //    if (dto.Products != null)
        //    {
        //        foreach (var a in dto.Products)
        //        {
        //            var product = new Product();
        //            product.Image = await _fileService.SaveFile(a, FolderNames.ImagesFolder);
        //            product.Id = mrket.Id;
        //            await _db.Products.AddAsync(product);
        //            await _db.SaveChangesAsync();
        //        }
        //    }
        //    return mrket.Id;
        //}




        public async Task<List<MarketViewModel>> NearMe(string userId)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            var markets = await _db.Markets.ToListAsync();
            var distances = new Dictionary<int, double>();

            var userLocation = new Coordinates((double)user.Latitude, (double)user.Longitude);

            foreach (var market in markets)
            {
                var marketLocation = new Coordinates((double)market.Latitude, (double)market.Longitude);
                var distancKM = userLocation.DistanceTo(marketLocation);
                distances.Add(market.Id, distancKM);
            }

            var nearIds = distances.OrderBy(x => x.Value).Take(5).Select(x => x.Key).ToList();

            var nearMarkets = _db.Markets.Where(x => nearIds.Contains(x.Id)).ToList();

            return _mapper.Map<List<MarketViewModel>>(nearMarkets);
        }


    }
}
