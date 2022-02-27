using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    [Route("api/upload")]
    [ApiController]
    public class FileUploadController
    {
        private IHostingEnvironment hostingEnv;

        public FileUploadController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }
        [HttpPost("[action]")]
        public void Save(IList<IFormFile> chunkFile, IList<IFormFile> UploadFiles)
        {
            long size = 0;
            try
            {
                foreach (var file in UploadFiles)
                {
                    var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
                    var folders = filename.Split('/');
                    var uploaderFilePath = hostingEnv.ContentRootPath;
                    // for Directory upload
                    if (folders.Length > 1)
                    {
                        for (var i = 0; i < folders.Length - 1; i++)
                        {
                            var newFolder = uploaderFilePath + $@"\{folders[i]}";
                            Directory.CreateDirectory(newFolder);
                            uploaderFilePath = newFolder;
                            filename = folders[i + 1];
                        }
                    }
                    filename = uploaderFilePath + $@"\{filename}";
                    size += file.Length;
                    if (!File.Exists(filename))
                    {
                        using (FileStream fs = File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                    }
                }
            }
            catch (Exception e)
            {
                
            }
        }

        [HttpPost("[action]")]
        public void Remove(IList<IFormFile> UploadFiles)
        {
            try
            {
                var filename = hostingEnv.ContentRootPath + $@"\{UploadFiles[0].FileName}";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }
            catch (Exception e)
            {
                
            }
        }

    }
}
