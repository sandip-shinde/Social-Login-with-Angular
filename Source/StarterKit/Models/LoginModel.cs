using System;
using System.Collections.Generic;
using System.Text;
using StarterKit.Common.Helper.Interface;

namespace StarterKit.Models
{
    public class LoginModel : BaseModel
    {
        public LoginModel(ILocalizationService localizationService) : base(localizationService)
        {
        }

        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        private bool _isShowAuthValidationMessage;
        public bool IsShowAuthValidationMessage
        {
            get
            {
                return _isShowAuthValidationMessage;
            }
            set
            {
                _isShowAuthValidationMessage = value;
                RaisePropertyChanged(() => IsShowAuthValidationMessage);
            }
        }

        private string _authValidationMessage;
        public string AuthValidationMessage
        {
            get
            {
                return _authValidationMessage;
            }
            set
            {
                _authValidationMessage = value;
                RaisePropertyChanged(() => AuthValidationMessage);
            }
        }
        

    }
}
