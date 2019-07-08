using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Xpanxion.MicroService.Api.CloudServices.Azure.Interfaces;
using Xpanxion.MicroService.Api.Common.Enums;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud;
using Xpanxion.MicroService.Api.Integration.Contracts.Response.Cloud;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;
namespace Xpanxion.MicroService.Api.Integration.RequestHandler.CloudHandlers
{
	public class BlobStorageGetRequestHandler: BaseRequestHandler<BlobStorageGetRequest, BlobStorageGetResponse>
	{
		readonly IBlobStorageManager _blobManager;
		public BlobStorageGetRequestHandler(IBlobStorageManager blobStorageManager, IMapper mapper,
			IRequestValidator<BlobStorageGetRequest> requestValidator) : base(mapper, requestValidator)
		{
			_blobManager = blobStorageManager;
		}

		protected override Task<BlobStorageGetResponse> HandleRequestAsync(BlobStorageGetRequest request)
		{
			var response = new BlobStorageGetResponse();
			var blobContent=_blobManager.GetBlob(request.ConnectionString, request.ContainerName,request.BlobName).Result;
			response.Error = blobContent!=null ? null : new ApiError(ErrorCode.BlobNotFound);
			response.BlobContent = blobContent;
			return Task.FromResult(response);
		}
	}
}
