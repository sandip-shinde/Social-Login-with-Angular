using ModernHttpClient;
using StarterKit.Common.Helper;
using StarterKit.RequestHandler.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarterKit.RequestHandler.Helpers
{
    public class ApiProxy : IApiProxy
    {
        HttpClient CreateClient(bool addAuthHeader = false, string token = null)
        {
            var client = new HttpClient(new NativeMessageHandler());
            client.Timeout = TimeSpan.FromMilliseconds(Constant.TimeoutFotHttpsCallMilliSec);
            if (addAuthHeader)
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }

            return client;
        }

        public async Task<HttpResponseMessage> GetAsync(string url, bool addAuthHeader = false, string token = null)
        {
            HttpResponseMessage response = null;
            var cts = new CancellationTokenSource();
            try
            {
                using (var client = CreateClient(addAuthHeader, token))
                {
                    var address = string.Format("{0}{1}", Constant.BaseApiUrl, url);
                    response = await client.GetAsync(address, cts.Token);
                }

                return response;
            }
            catch (TaskCanceledException)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
            finally
            {
                cts.Dispose();
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string apiEndpoint, string jsonRequest, bool addAuthHeader = false, string token = null)
        {
            HttpResponseMessage response = null;
            try
            {
                HttpRequestMessage req = null;
                using (var client = new HttpClient())
                {
                    var address = string.Format("{0}{1}", Constant.BaseApiUrl, apiEndpoint);
                    req = new HttpRequestMessage(HttpMethod.Post, address) { Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json") };
                    response = await client.SendAsync(req);
                }
                return response;
            }
            catch (TaskCanceledException)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
            finally
            {

            }
        }

    }
}
