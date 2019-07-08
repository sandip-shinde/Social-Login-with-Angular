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
	public class BlobStoragePostRequestHandler: BaseRequestHandler<BlobStoragePostRequest, BlobStoragePostResponse>
	{
		readonly IBlobStorageManager _blobManager;
		public BlobStoragePostRequestHandler(IBlobStorageManager blobStorageManager, IMapper mapper, 
			IRequestValidator<BlobStoragePostRequest> requestValidator) : base(mapper, requestValidator)
		{
			_blobManager = blobStorageManager;
		}

		protected override Task<BlobStoragePostResponse> HandleRequestAsync(BlobStoragePostRequest request)
		{
			var response = new BlobStoragePostResponse();

			if (_blobManager.AddBlob(request.ConnectionString, request.ContainerName, request.DirectoryName,
				request.BlobName, request.BlobContent))
			{
				response.Error = null;				
			}
			else
				response.Error = new ApiError(ErrorCode.BlobAlreadyExist);

			return Task.FromResult<BlobStoragePostResponse>(response);
		}
	}
}
