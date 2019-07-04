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
		private static CloudBlobClient _blobClient;		
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

		public byte[] GetBlob(string connectionString,string containerName, string blobName)
		{
			var client = GetBlobClientObject(connectionString);
			var container = client.GetContainerReference(containerName);
			var blockBlob = container.GetBlockBlobReference(blobName);
			blockBlob.FetchAttributesAsync();
			var fileByteLength = blockBlob.Properties.Length;
			var fileContents = new byte[fileByteLength];
			blockBlob.DownloadToByteArrayAsync(fileContents, 0);
			return fileContents;
		}

		public bool AddBlob(string connectionString, string containerName, string directoryName, string blobName, byte[] blobContent)
		{
			return ExecuteWithExceptionHandlingAndReturnValue(
				() =>
				{
					var client=GetBlobClientObject(connectionString);
					var container = client.GetContainerReference(containerName);
					container.CreateIfNotExistsAsync();
					var blockblob = _container.GetBlockBlobReference(blobName);					
					using (var stream = new MemoryStream(blobContent, false))
					{
						blockblob.UploadFromStreamAsync(stream);						
					}
				});
		}

		private CloudBlobClient GetBlobClientObject(string connectionString)
		{
			if (_blobClient != null) return _blobClient;
			_storageAccount = CloudStorageAccount.Parse(connectionString);
			_blobClient = _storageAccount.CreateCloudBlobClient();
			return _blobClient;
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

		//public Task<byte[]> GetBlob(string containerName, string directoryName, string blobName)
		//{
		//	throw new NotImplementedException();
		//}

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
