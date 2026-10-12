using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CoworkingSpaceSystem.BLL.Helpers
{
    public class DocumentSettings:IDocumentSettings
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
          public DocumentSettings( IWebHostEnvironment webHostEnvironment)
        {

            _webHostEnvironment = webHostEnvironment;

        }

        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", folderName);

            if (!Directory.Exists((folderPath)))
                Directory.CreateDirectory(folderPath);
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(folderPath, fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return fileName;
        }

        public bool DeletedFile(string fileName, string folderName)
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName, folderName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }

            return false;
        }
    }
}
