using MediatR;
using PhotoProject.Application.Abstractions.Services.AppUserServices;
using PhotoProject.Application.DTOs.AppUserDTOs.UserLoginDTOs;
using PhotoProject.Application.DTOs.TokenDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Features.Commands.AccountCommands.UserLoginCommands
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, UserLoginCommandResponse>
    {

        private readonly IAppUserService _appUserService;

        public UserLoginCommandHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<UserLoginCommandResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {

            TokenDto tokenDto = await _appUserService.UserLoginAsync(new UserLoginDto()
            {
                Password = request.Password,
                UserNameOrEmail = request.UserNameOrEmail
            });

            return new UserLoginCommandResponse()
            {
                TokenDto = tokenDto
            };
        }
    }
}
