using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.CloudServices.Azure.Interfaces;

namespace Xpanxion.MicroService.Api.CloudServices.Azure
{
	public class BlobStorageManager : IBlobStorageManager
	{
		private CloudBlobClient _blobClient;		
		private CloudBlobContainer _container;	
		private CloudBlockBlob _blob;		
		private CloudStorageAccount _storageAccount;

		//public BlobStorageManager()
		//{
		//	// TODO: replace empty strings with credentials from azure key vault
		//	storageCredentials = new StorageCredentials("", "");
		//	storageAccount = new CloudStorageAccount(storageCredentials, true);
		//	blobClient = storageAccount.CreateCloudBlobClient();
		//	container = blobClient.GetContainerReference(containerName);
		//}

		//public BlobStorageManager(string containerName, StorageCredentials _storageCredentials)
		//{
		//	storageAccount = new CloudStorageAccount(_storageCredentials, true);
		//	blobClient = storageAccount.CreateCloudBlobClient();
		//	container = blobClient.GetContainerReference(containerName);
		//}

		public bool AddBlob(string connectionString, string containerName, string directoryName, string blobName, byte[] blobContent)
		{
			return ExecuteWithExceptionHandlingAndReturnValue(
				() =>
				{
					_storageAccount = CloudStorageAccount.Parse(connectionString);
					_blobClient = _storageAccount.CreateCloudBlobClient();
					_container = _blobClient.GetContainerReference(containerName);
					_container.CreateIfNotExistsAsync();
					_blob = _container.GetBlockBlobReference(blobName);					
					using (var stream = new MemoryStream(blobContent, false))
					{
						_blob.UploadFromStreamAsync(stream);						
					}
				});
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

		private void ExecuteWithExceptionHandling(Action action)
		{
			try
			{
				action();
			}
			catch (StorageException ex)
			{
				//Blob service error codes: https://msdn.microsoft.com/en-au/library/azure/dd179439.aspx
				//Ignore lease already present error
				if (ex.RequestInformation.ExtendedErrorInformation.ErrorCode != "409")
				{
					throw;
				}
			}
		}

		
		private bool ExecuteWithExceptionHandlingAndReturnValue(Action action)
		{
			try
			{
				action();
				return true;
			}
			catch (StorageException ex)
			{
				//Blob service error codes: https://msdn.microsoft.com/en-au/library/azure/dd179439.aspx
				//Ignore lease already present error
				if (ex.RequestInformation.ExtendedErrorInformation.ErrorCode != "409")
				{
					return false;
				}
				throw;
			}
		}
	}
}
