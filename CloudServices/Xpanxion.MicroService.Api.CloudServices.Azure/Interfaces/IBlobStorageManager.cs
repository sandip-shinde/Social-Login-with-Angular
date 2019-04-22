using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xpanxion.MicroService.Api.CloudServices.Azure.Interfaces
{
    public interface IBlobStorageManager
    {
        Task<bool> CreateContainer(string containerName);
        Task<bool> DoesContainerExist(string containerName);
        Task<bool> DeleteContainer(string containerName);
        Task<bool> CreateDirectory(string containerName, string directoryName);
        Task<bool> DoesDirectoryExist(string containerName, string directoryName);
        Task<bool> DeleteDirectory(string containerName, string directoryName);
        Task<bool> AddBlob(string containerName, string directoryName, string blobName, byte[] blobContent);
        Task<bool> UpdateBlob(string containerName, string directoryName, string blobName, byte[] blobContent);
        Task<bool> DoesBlobExist(string containerName, string directoryName, string blobName);
        Task<byte[]> GetBlob(string containerName, string directoryName, string blobName);
        Task<bool> DeleteBlob(string containerName, string directoryName, string blobName);
        Task<bool> CopyBlobsFromSourceDirectoryToTargetDirectory(string containerName, string sourceDirectory, string targetDirectory);
    }
}
