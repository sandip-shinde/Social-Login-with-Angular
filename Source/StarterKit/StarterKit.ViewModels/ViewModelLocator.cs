using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.ViewModels
{
    public class ViewModelLocator
    {    

        public LoginViewModel LoginViewModel
        {
            get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); }            
        }

    }
}
