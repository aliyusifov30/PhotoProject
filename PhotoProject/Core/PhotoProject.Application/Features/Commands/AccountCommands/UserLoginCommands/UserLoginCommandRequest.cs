using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Features.Commands.AccountCommands.UserLoginCommands
{
    public class UserLoginCommandRequest : IRequest<UserLoginCommandResponse>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
