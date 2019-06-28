using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud
{
	public class BlobStorageApiRequest
	{		
		public string BlobName { get; set; }
		public byte[] BlobContent { get; set; }
		public string DirectoryName { get; set; }
		public string ContainerName { get; set; }
	}
}
