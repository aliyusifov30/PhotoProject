using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PhotoProject.Application.Abstractions.Services.AppUserServices;
using PhotoProject.Application.Abstractions.Services.TokenServices;
using PhotoProject.Application.DTOs.AppUserDTOs.UserLoginDTOs;
using PhotoProject.Application.DTOs.AppUserDTOs.UserRegisterDTOs;
using PhotoProject.Application.DTOs.JwtDTOs;
using PhotoProject.Application.DTOs.TokenDTOs;
using PhotoProject.Domain.Entities.Identity;

namespace PhotoProject.Persistence.Services.AppUserServices
{
    public class AppUserService : IAppUserService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly JwtDto _jwtDto;
        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IOptions<JwtDto> jwtDto)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _jwtDto = jwtDto.Value;
        }

        public async Task<TokenDto> UserLoginAsync(UserLoginDto userLoginDto)
        {
            AppUser user = await _userManager.FindByNameAsync(userLoginDto.UserNameOrEmail);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(userLoginDto.UserNameOrEmail);
                if (user == null)
                    throw new Exception("User not found");
                    //todo change to special exception
            }

            var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);

            if (!result.Succeeded)
                throw new Exception("UserName or Password is wrong");


            var roleList = await _userManager.GetRolesAsync(user);

            var token = _tokenHandler.CreateAccessToken(user, _jwtDto.TokenSecond , roleList);
            //todo get this second from appsettings - i wrote this

            return await token;
        }

        public async Task<UserRegisterReturnDto> UserRegisterAsync(UserRegisterDto userRegisterDto)
        {
            AppUser user = new AppUser
            {
                Email = userRegisterDto.Email,
                UserName = userRegisterDto.UserName,
                FullName = userRegisterDto.FullName,
            };

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return new UserRegisterReturnDto
                    {
                        IsSuccess = result.Succeeded,
                        Message = error.Description
                    };
                    //todo if you want you change this to exception
                }
            }

            await _userManager.AddToRoleAsync(user, "Member"); //todo change this word to enum

            return new UserRegisterReturnDto()
            {
                IsSuccess = result.Succeeded,
                Message = "Everything is good"
            };
        }
    }
}
