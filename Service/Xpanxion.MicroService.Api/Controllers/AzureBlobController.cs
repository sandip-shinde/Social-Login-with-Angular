using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Xpanxion.MicroService.Api.Integration.Contracts;
using Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud;
using Xpanxion.MicroService.Api.Integration.Contracts.Response.Cloud;
using Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces;
namespace Xpanxion.MicroService.Api.Controllers
{
	[Route("api/[controller]")]
	public class AzureBlobController:BaseApiController
	{
		private readonly AppSettings _appSettings;
		public AzureBlobController(IRequestHandlerProvider requestHandlerProvider, IOptions<AppSettings> appSettings) : base(requestHandlerProvider)
		{
			_appSettings = appSettings.Value;
		}
		[HttpPost]
		[Route("Add")]
		public async Task<IActionResult> AddBlob([FromBody]BlobStoragePostApiRequest apiRequest)
		{
			var request = new BlobStoragePostRequest
			{
				ConnectionString = _appSettings.AzureStorageAccountConnectionString,
				ContainerName = apiRequest.ContainerName,
				BlobContent = apiRequest.BlobContent,
				BlobName= apiRequest.BlobName
			};
			var result = await RequestHandler.ProcessRequestAsync<BlobStoragePostRequest, BlobStoragePostResponse>(request);
			return Ok(result);
		}
		[HttpPost]
		[Route("Get")]
		public async Task<IActionResult> GetBlob([FromBody]BlobStorageGetApiRequest apiRequest)
		{
			var request = new BlobStorageGetRequest
			{
				ConnectionString = _appSettings.AzureStorageAccountConnectionString,
				ContainerName = apiRequest.ContainerName,				
				BlobName = apiRequest.BlobName
			};
			var result = await RequestHandler.ProcessRequestAsync<BlobStorageGetRequest, BlobStorageGetResponse>(request);
			return Ok(result);
		}
	}
}
