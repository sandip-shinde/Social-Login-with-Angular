using StarterKit.Contracts.Response;
using StarterKit.Contracts.Types;
using StarterKit.RequestHandler.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StarterKit.RequestHandler.Helpers
{
    public class BaseRequestHandler
    {
        public IApiProxy OtisApiProxy;

        public BaseRequestHandler(IApiProxy otisApiProxy)
        {
            this.OtisApiProxy = otisApiProxy;
        }
    }
}
