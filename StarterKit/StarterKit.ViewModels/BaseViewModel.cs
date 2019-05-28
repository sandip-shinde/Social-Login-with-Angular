using AutoMapper;
using StarterKit.Common.Helper.Interface;
using StarterKit.Common.Interface;
using StarterKit.RequestHandler.Interfaces;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace StarterKit.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IRequestHandlerProvider RequestHandlerProvider;
        public ILocalizationService LocalizationService;
        public INavigationService NavService;
        public IMapper ModelContractMapper;

        bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;

            }
            set
            {
                isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        string loadingText;
        public string LoadingText
        {
            get
            {
                return loadingText;
            }
            set
            {
                loadingText = value;
                RaisePropertyChanged(() => LoadingText);
            }
        }

        public BaseViewModel(
            IRequestHandlerProvider requestHandlerProvider, 
            ILocalizationService localizationService, 
            INavigationService navigationService,
            IMapper mapper)
        {
            this.RequestHandlerProvider = requestHandlerProvider;
            this.LocalizationService = localizationService;
            this.NavService = navigationService;
            this.ModelContractMapper = mapper;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(Expression<Func<object>> propertyExpression)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(GetPropertyName(propertyExpression)));
        }

        string GetPropertyName(Expression<Func<object>> propertyExpression)
        {
            var unaryExpression = propertyExpression.Body as UnaryExpression;
            var memberExpression = unaryExpression == null ? (MemberExpression)propertyExpression.Body : (MemberExpression)unaryExpression.Operand;
            var propertyName = memberExpression.Member.Name;
            return propertyName;
        }
    }
}
