using AutoMapper;
using BestOfferings.API.Data;
using BestOfferings.Core.Dtos;
using BestOfferings.Core.ViewModels;
using BestOfferings.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BestOfferingsDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(BestOfferingsDbContext db, IMapper mapper, UserManager<User> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<UserViewModel>> GetAll(string serachKey)
        {
            var users = _db.Users.Where(x => x.FullName.Contains(serachKey) || x.PhoneNumber.Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey)).ToList();
            return _mapper.Map<List<UserViewModel>>(users);
        }



        public async Task<ResponseDto> GetAllUsers(Pagination pagination, Query query)
        {
            var queryString = _db.Users.Where(x => !x.IsDelete && (x.FullName.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch) || x.PhoneNumber.Contains(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var users = _mapper.Map<List<UserViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = users,
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


        public async Task<string> Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.UserName = dto.PhoneNumber;
            await _userManager.CreateAsync(user, dto.Password);
            return user.Id;
        }

        public async Task<string> Update(UpdateUserDto dto)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == dto.Id);
            if (user == null)
            {
                //throw 
            }
            var updatedUser = _mapper.Map(dto, user);
            _db.Users.Update(updatedUser);
            _db.SaveChanges();
            return user.Id;
        }

        public async Task<string> Delete(string Id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == Id);
            if (user == null)
            {
                //throw 
            }
            user.IsDelete = true;
            _db.Users.Update(user);
            _db.SaveChanges();
            return user.Id;
        }

        public async Task<UpdateUserDto> Get(string Id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == Id);
            if (user == null)
            {
                //throw 
            }
            return _mapper.Map<UpdateUserDto>(user);
        }




    }
}