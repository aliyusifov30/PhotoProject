using MediatR;
using PhotoProject.Application.Abstractions.Services.AppUserServices;
using PhotoProject.Application.DTOs.AppUserDTOs.UserRegisterDTOs;

namespace PhotoProject.Application.Features.Commands.AccountCommands.UserRegisterCommands
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommandRequest, UserRegisterCommandResponse>
    {

        private readonly IAppUserService _appUserService;

        public UserRegisterCommandHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<UserRegisterCommandResponse> Handle(UserRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            UserRegisterReturnDto createUserReturnDto = await _appUserService.UserRegisterAsync(new()
            {
                ConfirmPassword = request.ConfirmPassword,
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                UserName = request.UserName
                //todo change this to Mapping profile
            });

            return new UserRegisterCommandResponse()
            {
                IsSuccess = createUserReturnDto.IsSuccess,
                Message = createUserReturnDto.Message
            };
        }
    }
}
