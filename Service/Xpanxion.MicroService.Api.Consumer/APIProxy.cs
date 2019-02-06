using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Xpanxion.MicroService.Api.Consumer
{
    public class ApiProxy
    {
        private HttpClient CreateClient(bool addAuthHeader = false, string token = null)
        {
            var client = new HttpClient(new NativeMessageHandler());
            client.Timeout = TimeSpan.FromMilliseconds(Constants.TimeoutFotHttpsCallMilliSec);
            if (addAuthHeader)
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }
            return client;
        }

        public async Task<HttpResponseMessage> GetAsync(string url, bool addAuthHeader = false, string token = null)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var client = CreateClient(addAuthHeader, token))
                {
                    response = await client.GetAsync(url);
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
            }
        }


        public async Task<HttpResponseMessage> PostAsyncEncodedContent(string apiEndpoint, string jsonRequest, bool addAuthHeader = false, string token = null)
        {
            HttpResponseMessage response = null;
            try
            {
                HttpRequestMessage req = null;
                using (var client = new HttpClient())
                {
                    var address = string.Format("{0}{1}", Constants.APIURL, apiEndpoint);
                    req = new HttpRequestMessage(HttpMethod.Post, address) { Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json") };

                    /*if (apiType == ApiType.WeboxAppApi)
                    {
                        address = string.Format("{0}{1}", Constants.BaseWeboxAppApi, apiEndpoint);
                        req = new HttpRequestMessage(HttpMethod.Post, address) { Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json") };
                    }
                    else if (apiType == ApiType.ChatApi)
                    {
                        address = string.Format("{0}{1}?token={2}", Constants.BaseAPIUrl, apiEndpoint, Constants.ApiToken);
                        req = new HttpRequestMessage(HttpMethod.Post, address) { Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json") };
                    }
                    else if (apiType == ApiType.ClickaTellApi)
                    {
                        address = string.Format("{0}{1}", Constants.BaseAPIUrl, apiEndpoint);
                        req = new HttpRequestMessage(HttpMethod.Post, address);
                        req.Headers.Add("Accept", "application/json");
                        req.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", Constants.ApiToken);
                    }*/

                    response = await client.SendAsync(req);
                }
                //}

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
