using MediatR;

namespace PhotoProject.Application.Features.Commands.AccountCommands.UserRegisterCommands
{
    public class UserRegisterCommandRequest : IRequest<UserRegisterCommandResponse>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
