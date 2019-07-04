using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.CloudServices.Azure.Interfaces
{
    public interface IBlobStorageManager
    {
	    bool AddBlob(string connectionString, string containerName, string directoryName, string blobName,
		    byte[] blobContent);

	    byte[] GetBlob(string connectionString, string containerName, string blobName);


    }
}
