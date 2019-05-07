using Newtonsoft.Json;
using StarterKit.Common.Enums;
using StarterKit.Common.Helper;
using StarterKit.Contracts.Request;
using StarterKit.Contracts.Response;
using StarterKit.RequestHandler.Helpers;
using StarterKit.RequestHandler.Interfaces;
using StarterKit.SQLite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarterKit.RequestHandler
{
    public class AuthenticationRequestHandler : BaseRequestHandler, IRequestHandler<AuthenticationRequest, AuthenticationResponse>
    {
        IUserRepository userRepository;

        public AuthenticationRequestHandler(IApiProxy otisApiProxy, IUserRepository userRepo) : base(otisApiProxy)
        {
            this.userRepository = userRepo;
        }

        public Task<AuthenticationResponse> ProcessRequestAsync(AuthenticationRequest request)
        {

            //TODO : Call a backend API 
            //TODO : If backend api returns true , then store success response in sqllite database.
            string apiRequest = JsonConvert.SerializeObject(request);
            var response = JsonConvert.DeserializeObject(this.OtisApiProxy.PostAsync(APIEndPoints.Authenticate.EnumToStringValue(), apiRequest, false, Guid.NewGuid().ToString()).Result.Content.ReadAsStringAsync().Result);


            return null;
            //throw new NotImplementedException();
        }
    }
}
