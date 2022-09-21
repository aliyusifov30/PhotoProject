using MediatR;
using Microsoft.AspNetCore.Http;
using PhotoProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Features.Commands.PostCommands
{
    public class PostShareCommandRequest : IRequest<PostShareCommandResponse>
    {
        public string Description { get; set; }
        public string? IdentityName { get; set; }
        public IFormFile FormFile { get; set; }
        
        //todo add tags

    }
}
