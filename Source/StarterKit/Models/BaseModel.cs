using StarterKit.Common.Helper.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace StarterKit.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public ILocalizationService LocalizationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(Expression<Func<object>> propertyExpression)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(GetPropertyName(propertyExpression)));
        }

        private string GetPropertyName(Expression<Func<object>> propertyExpression)
        {
            var unaryExpression = propertyExpression.Body as UnaryExpression;
            var memberExpression = unaryExpression == null ? (MemberExpression)propertyExpression.Body : (MemberExpression)unaryExpression.Operand;
            var propertyName = memberExpression.Member.Name;
            return propertyName;
        }

        public BaseModel(ILocalizationService localizationService)
        {
            this.LocalizationService = localizationService;
        }
    }
}
