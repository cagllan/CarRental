using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public static class ImageUploadHelper
    {
        //public static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        public static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        public static string path = @"/uploads/images/";
        public static string defaultImage = "default.png";

        public static string AddImage(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string newGuidFileName = Guid.NewGuid() + extension;

            if (!Directory.Exists(directory + path))
            {
                Directory.CreateDirectory(directory + path);
            }

            using (FileStream fileStream = File.Create(directory + path + newGuidFileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            return (path + newGuidFileName).Replace("\\", "/");
        }


        public static void DeleteImage(string imagePath)
        {
            if (File.Exists(directory + imagePath.Replace("/", "\\")) && Path.GetFileName(imagePath) != defaultImage)
            {
                File.Delete(directory + imagePath.Replace("/", "\\"));
            }
        }

        public static string UpdateImage(IFormFile file, string oldImagePath)
        {
            DeleteImage(oldImagePath);
            return AddImage(file);
        }

        public static string DefaultImagePath()
        {
            return path + defaultImage;
        }
    }
}
