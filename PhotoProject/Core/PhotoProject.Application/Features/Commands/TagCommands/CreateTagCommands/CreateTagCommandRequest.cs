using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Features.Commands.TagCommands.CreateTagCommands
{
    public class CreateTagCommandRequest : IRequest<CreateTagCommandResponse>
    {
        public string Name { get; set; }
    }
}
