using AutoMapper;
using StarterKit.Common.Helper.Interface;
using StarterKit.Common.Interface;
using StarterKit.Contracts.Request;
using StarterKit.Contracts.Response;
using StarterKit.Models;
using StarterKit.RequestHandler.Interfaces;
using Xamarin.Forms;

namespace StarterKit.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public LoginModel Model { get; set; }
        public LoginViewModel(IRequestHandlerProvider requestHandlerProvider,
            ILocalizationService localizationService,
            INavigationService navigationService,
            IMapper mapper) : base(requestHandlerProvider, localizationService, navigationService,mapper)
        {
            this.Model = new LoginModel(localizationService);
            IsLoading = false;
        }

        public Command LogonCommand => new Command( async() => {

            AuthenticationRequest authenticationRequest = this.ModelContractMapper.Map<LoginModel, AuthenticationRequest>(this.Model);

            await this.RequestHandlerProvider.ProcessRequestAsync<AuthenticationRequest, AuthenticationResponse>(authenticationRequest)
            .ContinueWith(result => {
                if (!result.IsFaulted)
                {
                    var authenticationResponse = result.Result as AuthenticationResponse;
                    if (authenticationResponse.IsAuthenticated)
                    {
                        // TODO : Navigate to Diffrent viewmodel
                    }
                    else
                    {
                        // TODO : Show Error Message
                    }
                }
            });

        });

        public Command NavigateToForgotPasswordPageCommand => new Command(async () =>
       {
           string todo = "Navigate to Forgot Password Page";
       });

        public Command NavigateToRegisterPageCommand => new Command(async () =>
        {
            string todo = "Navigate to Register User Page";
        });
    }
}
