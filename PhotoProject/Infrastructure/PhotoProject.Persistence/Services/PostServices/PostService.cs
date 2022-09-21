using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PhotoProject.Application.Abstractions.Services;
using PhotoProject.Application.Abstractions.Services.PostServices;
using PhotoProject.Application.DTOs.PostDTOs.PostServiceDTOs;
using PhotoProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Persistence.Services.PostServices
{
    public class PostService : IPostService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public PostService(UserManager<AppUser> userManager, IFileService fileService, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _fileService = fileService;
            _env = env;
        }

        public async Task<PostShareReturnDto> PostShare(string identityName , IFormFile formFile)
        {
            AppUser user = await _userManager.FindByNameAsync(identityName);

            string path = Path.Combine(_env.WebRootPath, "uploads", "posts/");

            string newPath = await _fileService.UploadAsync(path, formFile);

            return new PostShareReturnDto()
            {
                Path = newPath,
                AppUserId = user.Id
            };
        }
    }
}
