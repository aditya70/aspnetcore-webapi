using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;

namespace ApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        //public async Task<bool> Upload()
        //{
        //    try
        //    {
        //        var fileuploadPath = ConfigurationManager.AppSettings["FileUploadLocation"];

        //        var provider = new MultipartFormDataStreamProvider(fileuploadPath);
        //        var content = new StreamContent(HttpContext..Request.GetBufferlessInputStream(true));
        //        foreach (var header in Request.Content.Headers)
        //        {
        //            content.Headers.TryAddWithoutValidation(header.Key, header.Value);
        //        }

        //        await content.ReadAsMultipartAsync(provider);

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = "D:\\UploadedFiles" ;

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                   
                    using (var stream = new FileStream(Path.Combine(filePath,formFile.FileName), FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }
    }
}