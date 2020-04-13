using Agatha.Application.Interfaces;
using Agatha.Application.ProductImages.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Agatha.Infrasctructure
{
    public class AzureService : IAzureService
    {
        private IConfiguration Configuration { get; }

        public AzureService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<string> UploadImageAsync(ImageUpload imageUpload)
        {
            string strorageconn = Configuration.GetConnectionString("StorageConnectionString");

            CloudStorageAccount storageacc = CloudStorageAccount.Parse(strorageconn);

            CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("products-images");

            container.CreateIfNotExists();

            var fileName = string.Concat(Guid.NewGuid().ToString(), ".jpg");

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            var imageBytes = Convert.FromBase64String(imageUpload.Base64Image.Replace("data:image/jpeg;base64,", string.Empty));

            await blockBlob.UploadFromByteArrayAsync(imageBytes, 0, imageBytes.Length);

            return blockBlob.Uri.AbsoluteUri;

        }

    }


}
