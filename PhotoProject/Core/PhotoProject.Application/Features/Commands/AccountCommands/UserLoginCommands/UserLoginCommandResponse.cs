using PhotoProject.Application.DTOs.TokenDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Features.Commands.AccountCommands.UserLoginCommands
{
    public class UserLoginCommandResponse
    {

        public TokenDto TokenDto { get; set; }

    }
}
