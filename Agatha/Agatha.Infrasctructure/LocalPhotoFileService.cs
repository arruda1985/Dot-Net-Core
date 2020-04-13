using Agatha.Application.Interfaces;
using Agatha.Application.ProductImages.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Agatha.Infrasctructure
{
    public class LocalPhotoFileService : ILocalPhotoFileService
    {
        private IConfiguration _configuration { get; }

        public LocalPhotoFileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Save(ImageUpload imageUpload)
        {
            var path = _configuration["LocalPhotoUploadFolder"] + Guid.NewGuid() + ".jpeg";

            var imageBytes = Convert.FromBase64String(imageUpload.Base64Image.Replace("data:image/jpeg;base64,", string.Empty));

            File.WriteAllBytes(path, imageBytes);

            return path;
        }
    }
}
