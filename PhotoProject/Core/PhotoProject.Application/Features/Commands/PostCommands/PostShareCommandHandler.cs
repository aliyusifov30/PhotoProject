using MediatR;
using PhotoProject.Application.Abstractions.Services.PostServices;
using PhotoProject.Application.DTOs.PostDTOs.PostServiceDTOs;
using PhotoProject.Application.Repositories.PostFileRepositories;
using PhotoProject.Domain.Entities;

namespace PhotoProject.Application.Features.Commands.PostCommands
{
    public class PostShareCommandHandler : IRequestHandler<PostShareCommandRequest, PostShareCommandResponse>
    {

        private readonly IPostFileWriteRepository _postFileWriteRepository;
        private readonly IPostService _postService;
        public PostShareCommandHandler(IPostFileWriteRepository postFileWriteRepository, IPostService postService)
        {
            _postFileWriteRepository = postFileWriteRepository;
            _postService = postService;
        }

        public async Task<PostShareCommandResponse> Handle(PostShareCommandRequest request, CancellationToken cancellationToken)
        {

            PostShareReturnDto postShareReturnDto = await _postService.PostShare(request.IdentityName, request.FormFile);

            PostFile postFile = new PostFile
            {
                Path = postShareReturnDto.Path,
            };

            await _postFileWriteRepository.InsertAsync(new Post()
            {
                Description = request.Description,
                PostFile = postFile,
                AppUserId = postShareReturnDto.AppUserId,
            });

            await _postFileWriteRepository.CommitAsync();

            return new PostShareCommandResponse()
            {
                Path = postFile.Path,
                AppUserId = postShareReturnDto.AppUserId
            };
        }
    }
}
