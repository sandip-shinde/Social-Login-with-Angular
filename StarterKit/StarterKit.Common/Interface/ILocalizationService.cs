using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StarterKit.Common.Helper.Interface
{
    public interface ILocalizationService
    {
        CultureInfo GetCurrentCulture();
    }
}
