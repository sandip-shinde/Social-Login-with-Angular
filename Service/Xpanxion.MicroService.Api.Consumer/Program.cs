using Newtonsoft.Json;
using System;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Response;

namespace Xpanxion.MicroService.Api.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //RegisterUserAPI();

            GetUserAPI();

            Console.ReadKey();
        }


        private static void RegisterUserAPI()
        {
            string request = JsonConvert.SerializeObject(new UserRegisterRequest
            {
                UserName = "TestUserName",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "TestAddress",
                EmailAddress = "test@hotmail.com",
                Password = "test@123",
                PrimaryContact = "12345678915",
                SecondaryContact = "5674321987",
                Token = Guid.NewGuid().ToString(),
            });

            ApiProxy apiProxy = new ApiProxy();
            var response = JsonConvert.DeserializeObject<UserRegisterResponse>(apiProxy.PostAsyncEncodedContent("user/register", request).Result.Content.ReadAsStringAsync().Result);
        }

        private static void GetUserAPI()
        {
            string request = JsonConvert.SerializeObject(new UserGetRequest
            {
                UserName = "TestUserName",
                Token = Guid.NewGuid().ToString(),
            });

            ApiProxy apiProxy = new ApiProxy();
            var response =  JsonConvert.DeserializeObject<UserGetResponse>(apiProxy.PostAsyncEncodedContent("user/getbyname", request).Result.Content.ReadAsStringAsync().Result);
        }
    }
}
