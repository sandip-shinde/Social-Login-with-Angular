using CommonServiceLocator;
using StarterKit.Common.Interface;
using StarterKit.RequestHandler.Interfaces;
using StarterKit.UI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StarterKit.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            //var requestHandlerProvider = ServiceLocator.Current.GetInstance<IRequestHandlerProvider>();
            //var navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            //navigationService.SetMainPage("LoginPage", null, false);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
