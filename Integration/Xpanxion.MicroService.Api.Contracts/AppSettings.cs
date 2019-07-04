using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts
{
	public class AppSettings
	{
		public string AzureStorageAccountConnectionString { get; set; }
		public string AzureServiceBusConnectionString { get; set; }
	}
}
