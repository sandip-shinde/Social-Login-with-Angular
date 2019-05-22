using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.CloudServices.Azure.Interfaces;

namespace Xpanxion.MicroService.Api.CloudServices.Azure.Implementation
{
    public class BlobStorageManager : IBlobStorageManager
    {
        private CloudBlobClient blobClient;
        private string containerName = "default_container";
        private CloudBlobContainer container;
        private string directoryName = "default_directory";
        private string blobName;
        private CloudBlockBlob blob;
        private StorageCredentials storageCredentials;
        private CloudStorageAccount storageAccount;

        public BlobStorageManager()
        {
            // TODO: replace empty strings with credentials from azure key vault
            storageCredentials = new StorageCredentials("", "");
            storageAccount = new CloudStorageAccount(storageCredentials, true);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(containerName);
        }

        public BlobStorageManager(string containerName, StorageCredentials _storageCredentials)
        {
            storageAccount = new CloudStorageAccount(_storageCredentials, true);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(containerName);
        }

        public Task<bool> AddBlob(string containerName, string directoryName, string blobName, byte[] blobContent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CopyBlobsFromSourceDirectoryToTargetDirectory(string containerName, string sourceDirectory, string targetDirectory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateContainer(string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateDirectory(string containerName, string directoryName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBlob(string containerName, string directoryName, string blobName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteContainer(string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDirectory(string containerName, string directoryName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesBlobExist(string containerName, string directoryName, string blobName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesContainerExist(string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesDirectoryExist(string containerName, string directoryName)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetBlob(string containerName, string directoryName, string blobName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBlob(string containerName, string directoryName, string blobName, byte[] blobContent)
        {
            throw new NotImplementedException();
        }
    }
}
