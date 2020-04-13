using Agatha.Application.ProductImages.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Application.Interfaces
{
    public interface ILocalPhotoFileService
    {
        string Save(ImageUpload imageUpload);
    }
}
