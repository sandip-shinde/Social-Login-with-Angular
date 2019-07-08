using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud
{
	public class BlobStorageGetRequest: BaseApiRequest
	{
		public string ConnectionString { get; set; }
		public string ContainerName { get; set; }		
		public string BlobName { get; set; }
	}
}
