using AutoMapper;
using AutoMapper.Configuration;
using BestOfferings.API.Data;
using BestOfferings.Core.Constant.Claims;
using BestOfferings.Core.Dtos.LoginDto;
using BestOfferings.Core.Exceptions;
using BestOfferings.Core.Options;
using BestOfferings.Core.ViewModels;
using BestOfferings.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BestOfferings.infrastructure.Services.AuthService
{
    public class AuthService : IAuthService
    {

        private readonly BestOfferingsDbContext _DB;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtOptions _options;


        public AuthService(IOptions<JwtOptions> options, BestOfferingsDbContext DB, UserManager<User> userManager, IMapper mapper)
        {
            _DB = DB;
            _userManager = userManager;
            _mapper = mapper;
            _options = options.Value;


        }



        public async Task<LoginResponseViewModel> Login(LoginDto dto)
        {
            var user = _DB.Users.SingleOrDefault(x => x.UserName == dto.Username && !x.IsDelete);

            if (user == null)
            {
                throw new InvalidUsernameOrPasswordException();
            }

            var result = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!result)
            {
                throw new InvalidUsernameOrPasswordException();
            }
       

           

            var response = new LoginResponseViewModel();
            response.AccessToken = await GenrateAccessToken(user);
            response.User = _mapper.Map<UserViewModel>(user);


            return response;

        }



        private async Task<AccessTokenViewModel> GenrateAccessToken(User user)
        {

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>(){
              new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
              new Claim(Claims.Phone, user.PhoneNumber),
              new Claim(Claims.UserId,user.Id),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            if (roles.Any())
            {
                claims.Add(new Claim(ClaimTypes.Role, string.Join(",", roles)));
            }


            var expires = DateTime.Now.AddMonths(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecurityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var accessToken = new JwtSecurityToken(_options.Issure,
             _options.Issure,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var result = new AccessTokenViewModel()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),

                ExpireAt =  expires
             };

            return result;
        }
    }
}
