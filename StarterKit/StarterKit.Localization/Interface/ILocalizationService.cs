using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OTIS.NE.Field.Localization.Interface
{
    public interface ILocalizationService
    {
        CultureInfo GetCurrentCulture();
    }
}
