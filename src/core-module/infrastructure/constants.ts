import { LoginOpt, AuthServiceConfig, GoogleLoginProvider, FacebookLoginProvider } from 'angularx-social-login';
import { environment } from '@env';

export class Constants {
        
    static cookies =
    {
        sessionId: "SessionId"
    }

    static requestHeader =
    {
        authorization: "Authorization",
        sessionId: "SessionId",
        bearer: "Bearer",
        accept: "Accept",
        contentType: "Content-Type"
    }

    static apiToken = {
        refreshToken: "grant_type=refresh_token&client_id=web&refresh_token="
    }

    static contentType =
    {
        json: "application/json",
        formUrlEncoded: "application/x-www-form-urlencoded",
        multiPart: "multipart/form-data"
    }

    static queryString = {
        SessionExpired: "SessionExpired=true",
        SessionKilled: "SessionKilled=true",
        me: "?me"
    }

    static localStorageKeys = {
        apiToken : "apiToken",
        isLoggedIn : "isLoggedIn",
        sessionId : "sessionId"
    }
    
    static googleLoginOptions: LoginOpt = {
        scope: 'profile email',
        return_scopes: true,
        enable_profile_selector: true
      }; 
      
      static fbLoginOptions: LoginOpt = {
        scope: 'email',
        return_scopes: true,
        enable_profile_selector: true
      };

      static config = new AuthServiceConfig(
        [          
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(environment.googleAuthenticationApi,Constants.googleLoginOptions)       
          },
          {
            id: FacebookLoginProvider.PROVIDER_ID,
            provider: new FacebookLoginProvider(environment.FaceBookAuthenticationApi,Constants.fbLoginOptions)       
          }
        ]
    );   
    
}