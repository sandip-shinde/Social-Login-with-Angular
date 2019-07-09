using AutoMapper;
using CommonServiceLocator;
using StarterKit.Common.Enums;
using StarterKit.Common.Helper;
using StarterKit.Common.Helper.Interface;
using StarterKit.Common.Interface;
using StarterKit.Contracts.Entities;
using StarterKit.Contracts.Request;
using StarterKit.Contracts.Response;
using StarterKit.Models;
using StarterKit.RequestHandler;
using StarterKit.RequestHandler.Helpers;
using StarterKit.RequestHandler.Interfaces;
using StarterKit.SQLite;
using StarterKit.SQLite.Interfaces;
using StarterKit.UI.Views;
using StarterKit.ViewModels;
using StarterKit.ViewModels.Helper;
using SQLite;
using System;
using System.Linq;
using Unity;
using Unity.ServiceLocation;
using RequestHandlerProvider = StarterKit.RequestHandler.Helpers.RequestHandlerProvider;

namespace StarterKit.UI
{
    public static class BootStrapper
    {
        private static UnityContainer _container;
        private static UnityServiceLocator _serviceLocator;
        public static UnityContainer Container
        {
            get
            {
                return _container;
            }
        }

        public static void Initialize(SQLiteConnection sqliteConnection)
        {
            _container = new UnityContainer();
            _serviceLocator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => _serviceLocator);
            RegisterRepositories(sqliteConnection);
            RegisterServices();
            RegisterCloudServices();
            RegisterRequestHandlers();
            RegisterViewModels();
            RegisterAppStart();
            InitializeMapper();
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            _container.RegisterInstance<IMapper>(config.CreateMapper());
        }

        private static void RegisterAppStart()
        {
        }


        private static void RegisterRepositories(SQLiteConnection sqliteConnection)
        {
            _container.RegisterInstance<SQLiteConnection>(sqliteConnection);
            _container.RegisterSingleton<IDBRepository<User>, DBRepository<User>>();
            _container.RegisterSingleton<IUserRepository, UserRepository>();
        }

        private static void RegisterServices()
        {
            _container.RegisterInstance<INavigationService>(GetNavigationService());
        }

        private static void RegisterCloudServices()
        {
            _container.RegisterSingleton<IApiProxy, ApiProxy>();
        }

        private static void RegisterRequestHandlers()
        {
            _container.RegisterSingleton<IRequestHandlerProvider, RequestHandlerProvider>();
            _container.RegisterSingleton<IRequestHandler<AuthenticationRequest, AuthenticationResponse>, AuthenticationRequestHandler>();
        }

        private static void RegisterViewModels()
        {
            //var assembly = typeof(StarterKit.ViewModels.BaseViewModel).Assembly;
            //var viewModelCollection = assembly.GetTypes().Where(x => x.IsClass && x.Name.EndsWith(ClassNames.ViewModel.ToString()));

            //foreach (Type viewModel in viewModelCollection)
            //{
            //    _container.RegisterInstance(viewModel);
            //}

            _container.RegisterInstance(typeof(BaseViewModel));
            _container.RegisterInstance(typeof(LoginViewModel));

        }
        private static INavigationService GetNavigationService()
        {
            NavigationService navigationService = new NavigationService();
            try
            {
               // var assembly = typeof(StarterKit.UI.App).Assembly;

                //var views = assembly.GetTypes().Where(x => x.IsClass && x.Name.EndsWith(ClassNames.Page.ToString()));

                //foreach (var view in views)
                //{
                //    navigationService.Configure(view.Name, view);
                //}

                navigationService.Configure("LoginPage", typeof(LoginPage));
            }
            catch (Exception)
            {

            }
            return navigationService;
        }

    }
}
