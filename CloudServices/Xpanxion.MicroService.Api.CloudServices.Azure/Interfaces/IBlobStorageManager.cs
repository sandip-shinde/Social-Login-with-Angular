using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xpanxion.MicroService.Api.CloudServices.Azure.Interfaces
{
    public interface IBlobStorageManager
    {
	    bool AddBlob(string connectionString, string containerName, string directoryName, string blobName,
		    byte[] blobContent);

        Task<byte[]> GetBlob(string connectionString, string containerName, string blobName);


    }
}
