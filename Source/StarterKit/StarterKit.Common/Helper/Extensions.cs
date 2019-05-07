using StarterKit.Common.Helper.Interface;
using System;
using System.Reflection;

namespace StarterKit.Common.Helper
{
    public static class Extensions
    {
        public static string Translate(this ILocalizationService localizeService, string str)
        {
            return null;
        }

        public static string EnumToStringValue(this Enum value){

            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            StringValueAttribute[] attrs =
                fi.GetCustomAttributes(typeof(StringValueAttribute),
                                        false) as StringValueAttribute[];
            if (attrs.Length > 0)
                output = attrs[0].Value;

            return output;
        }
    }
}
