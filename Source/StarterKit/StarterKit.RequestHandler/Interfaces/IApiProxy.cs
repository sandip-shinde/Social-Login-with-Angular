using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarterKit.RequestHandler.Interfaces
{
    public interface IApiProxy
    {
        Task<HttpResponseMessage> GetAsync(string url, bool addAuthHeader = false, string token = null);

        Task<HttpResponseMessage> PostAsync(string url, string data, bool addAuthHeader = false, string token = null);
        
    }
}
