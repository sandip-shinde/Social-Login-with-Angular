using Newtonsoft.Json;
using System;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;

namespace Xpanxion.MicroService.Api.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string request = JsonConvert.SerializeObject(new RegisterUserRequest
            {
                UserName = "TestUserName",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "TestAddress",
                EmailAddress = "test@hotmail.com",
                Password = "test@123",
                PrimaryContact = "1234567891",
                SecondaryContact = "5674321987",
                Token = Guid.NewGuid().ToString(),
            });

            ApiProxy apiProxy = new ApiProxy();
            apiProxy.PostAsyncEncodedContent("user/register", request).ContinueWith(result =>
            {
                Console.WriteLine(result);
            });

            Console.ReadKey();
        }
    }
}
