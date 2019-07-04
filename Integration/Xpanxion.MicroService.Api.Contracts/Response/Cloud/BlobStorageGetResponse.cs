using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Response.Cloud
{
	public class BlobStorageGetResponse:BaseApiResponse
	{
		public byte[] BlobContent { get; set; }
	}
}
