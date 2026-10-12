using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace CoworkingSpaceSystem.BLL.Helpers
{
    public interface IDocumentSettings
    {
        Task<string> UploadFileAsync(IFormFile file , string folderName);
        bool DeletedFile(string fileName,string folderName);

    }
}
