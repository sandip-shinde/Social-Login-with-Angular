using CommonServiceLocator;
using StarterKit.Common.Enums;
using StarterKit.Common.Helper;
using StarterKit.Common.Helper.Interface;
using System.Collections.Generic;

namespace StarterKit.Contracts.Types
{
    public static class ApiErrorCodes
    {
        public static string Unauthorized = "1001";
        public static string SqliteError = "1002";
        public static string LoginFailed = "1003";
        public static string InternetConnectionLossed = "1004";
        public static string FetchingDataError = "1005";
        public static string InternalServerError = "1006";
        public static string UserNotFound = "1007";
        public static string UserAlreadyExists = "1008";
        public static string RegistrationFailed = "1009";
        public static string InvalidOTPError = "1010";
        private static Dictionary<string, string> ErrorMessages { get; set; }
        static ApiErrorCodes()
        {
            ILocalizationService localizationService = ServiceLocator.Current.GetInstance<ILocalizationService>();
            ErrorMessages = new Dictionary<string, string>();
            ErrorMessages.Add(FetchingDataError, localizationService.Translate(LocalizedResourceType.MESSAGE_FETCHDATAERROR.ToString()));
            ErrorMessages.Add(LoginFailed, localizationService.Translate(LocalizedResourceType.MESSAGE_LOGINFAILED.ToString()));
            ErrorMessages.Add(Unauthorized, localizationService.Translate(LocalizedResourceType.MESSAGE_UNAUTHORIZED.ToString()));
            ErrorMessages.Add(InternalServerError, localizationService.Translate(LocalizedResourceType.MESSAGE_INTERNALSERVERERROR.ToString()));
            ErrorMessages.Add(InternetConnectionLossed, localizationService.Translate(LocalizedResourceType.MESSAGE_INTERNETCONNECTIONERROR.ToString()));
            ErrorMessages.Add(UserAlreadyExists, localizationService.Translate(LocalizedResourceType.USER_ALREADY_EXISTS.ToString()));
            ErrorMessages.Add(RegistrationFailed, localizationService.Translate(LocalizedResourceType.REGISTRATION_FAILED.ToString()));
            ErrorMessages.Add(InvalidOTPError, localizationService.Translate(LocalizedResourceType.INVALIDOTPERROR.ToString()));
        }

        public static string GetErrorMessage(string errorCode)
        {
            var message = string.Empty;
            if (ErrorMessages.TryGetValue(errorCode, out message))
                return message;
            return ErrorMessages[InternalServerError];
        }
    }
}
