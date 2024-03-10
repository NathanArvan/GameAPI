using Microsoft.AspNetCore.Mvc;
using System;

namespace GameAPI
{
    public class FileManager
    {
        public async Task<FileContentResult> GetFileAsync(ControllerBase controller, byte[] bytes, string filename, string mimeType)
        {
            return  controller.File(bytes, mimeType, filename);
        }
    }
}
