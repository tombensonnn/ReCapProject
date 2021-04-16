using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper 
    {

        public static string Add(IFormFile formFile)
        {
            var sourcePath = Path.GetTempFileName();

            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }

            var result = newPath(formFile);

            File.Move(sourcePath , result.newPath);

            return result.Path2;
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);

            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result.newPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);

            return result.Path2;
        }


        public static IResult Delete(string path)
        {
            File.Delete(path);
            return new SuccessResult();
        }


        public static (string newPath, string Path2) newPath(IFormFile formFile)
        {
            FileInfo ff = new FileInfo(formFile.FileName);
            string fileExtension = ff.Extension;
            string pathNameWithGuid = Guid.NewGuid().ToString() + fileExtension;
            string path = Environment.CurrentDirectory + @"\wwwroot\Images\";
            string result = $@"{path}\{pathNameWithGuid}";
            return (result, $"\\Images\\{pathNameWithGuid}");
        }
    }
}
