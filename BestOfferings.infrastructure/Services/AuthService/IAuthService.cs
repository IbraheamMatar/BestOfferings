using BestOfferings.Core.Dtos.LoginDto;
using BestOfferings.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services.AuthService
{
    public interface IAuthService
    {
        Task<LoginResponseViewModel> Login(LoginDto dto);
    }
}
