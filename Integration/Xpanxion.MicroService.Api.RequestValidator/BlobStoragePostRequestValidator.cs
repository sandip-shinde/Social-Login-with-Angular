using System;
using System.Collections.Generic;
using System.Text;
using Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api.RequestValidator
{
	public class BlobStoragePostRequestValidator: IRequestValidator<BlobStoragePostRequest>
	{
		public Integration.Contracts.Types.ValidationResult Validate(BlobStoragePostRequest request)
		{
			// TODO : Add Contract valudations or else return null

			return null;
		}
	}
}
