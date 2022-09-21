using Microsoft.AspNetCore.Http;
using PhotoProject.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Persistence.Services
{
    public class FileService : IFileService
    {
        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadAsync(string path, IFormFile formFile)
        {
            string fileName = formFile.FileName;

            if (formFile.FileName.Length > 64)
            {
                fileName = formFile.FileName.Substring(0, 64);
            }

            fileName = Guid.NewGuid().ToString() + fileName;

            path += fileName;

            FileStream stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);

            return path;
        }
    }
}
