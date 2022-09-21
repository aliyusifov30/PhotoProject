using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<string> UploadAsync(string path, IFormFile formFile);
        Task DeleteAsync();
    }
}
