using System;
using System.Collections.Generic;
using System.Text;
using Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api.RequestValidator
{
	public class BlobStorageRequestValidator: IRequestValidator<BlobStorageRequest>
	{
		public Integration.Contracts.Types.ValidationResult Validate(BlobStorageRequest request)
		{
			// TODO : Add Contract valudations or else return null

			return null;
		}
	}
}
