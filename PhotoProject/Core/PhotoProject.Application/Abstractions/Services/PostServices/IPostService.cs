using Microsoft.AspNetCore.Http;
using PhotoProject.Application.DTOs.PostDTOs.PostServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Abstractions.Services.PostServices
{
    public interface IPostService
    {
        Task<PostShareReturnDto> PostShare(string identityName , IFormFile formFile);
    }
}
