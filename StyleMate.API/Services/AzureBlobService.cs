using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;

namespace StyleMateAPI.Services
{
    public class AzureBlobService
    {

        private readonly BlobContainerClient _containerClient;

        public AzureBlobService(IConfiguration config)
        {
            string connectionString = config["AZURE_BLOB_CONNECTION"];
            string containerName = config["AzureBlobStorage:ContainerName"];

            _containerClient = new BlobContainerClient(connectionString, containerName);
            _containerClient.CreateIfNotExists(PublicAccessType.Blob);
        }

        public async Task<string> UploadAsync(Stream fileStream, string fileName)
        {
            var blobClient = _containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(fileStream, overwrite: true);

            return blobClient.Uri.ToString();
        }
    }
}
