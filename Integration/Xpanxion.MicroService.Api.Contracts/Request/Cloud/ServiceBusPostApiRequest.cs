﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud
{
    public class ServiceBusPostApiRequest
    {
        public string TopicName { get; set; }
        public string[] Subscribers { get; set; }
        public string Message { get; set; }
    }
}
