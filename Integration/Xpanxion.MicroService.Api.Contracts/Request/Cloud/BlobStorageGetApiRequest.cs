using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud
{
	public class BlobStorageGetApiRequest
	{
		public string BlobName { get; set; }	
		public string ContainerName { get; set; }
	}
}
