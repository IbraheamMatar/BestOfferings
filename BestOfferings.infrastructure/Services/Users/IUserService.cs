using BestOfferings.Core.Dtos;
using BestOfferings.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services.Users
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAll(string serachKey);
        Task<ResponseDto> GetAllUsers(Pagination pagination, Query query);
        Task<string> Create(CreateUserDto dto);
        Task<string> Update(UpdateUserDto dto);
        //Task<string> Delete(string id);
        Task<string> Delete(string Id);
        //Task<UserViewModel> Get(string id);
        Task<UpdateUserDto> Get(string Id);
    }
}
