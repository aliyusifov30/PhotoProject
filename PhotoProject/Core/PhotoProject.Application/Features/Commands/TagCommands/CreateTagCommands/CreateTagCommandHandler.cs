using MediatR;
using PhotoProject.Application.Repositories.TagRepositories;
using PhotoProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Features.Commands.TagCommands.CreateTagCommands
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, CreateTagCommandResponse>
    {

        private readonly ITagWriteRepository _tagWriteRepository;

        public CreateTagCommandHandler(ITagWriteRepository tagWriteRepository)
        {
            _tagWriteRepository = tagWriteRepository;
        }

        public async Task<CreateTagCommandResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {

            Tag tag = new Tag
            {
                Name = request.Name
            };

            await _tagWriteRepository.InsertAsync(tag);
            await _tagWriteRepository.CommitAsync();

            return new CreateTagCommandResponse
            {
                Message = "Succesed"
            };
        }
    }
}
