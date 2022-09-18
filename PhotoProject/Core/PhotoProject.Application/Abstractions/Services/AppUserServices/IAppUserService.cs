using PhotoProject.Application.DTOs.AppUserDTOs.UserLoginDTOs;
using PhotoProject.Application.DTOs.AppUserDTOs.UserRegisterDTOs;
using PhotoProject.Application.DTOs.TokenDTOs;

namespace PhotoProject.Application.Abstractions.Services.AppUserServices
{
    public interface IAppUserService
    {
        Task<UserRegisterReturnDto> UserRegisterAsync(UserRegisterDto userRegisterDto);
        Task<TokenDto> UserLoginAsync(UserLoginDto userLoginDto);
    }
}
