import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoggerService } from '@core';
 import {HttpError,ErrorCode,ErroNotificationType,UtilityService,ToastrService,AuthService} from '@core';
import { Constants } from '@shared';
import { LoginModel } from '../login/login.model';
import { LoginService } from '../login/login.service';
import { environment } from '@env';
import { AuthService as SocialAuthService,GoogleLoginProvider,FacebookLoginProvider } from 'angularx-social-login';

@Component({
  selector: 'app-social-login',
  templateUrl: './social-login.component.html',
  styleUrls: ['./social-login.component.css'],
  providers: [LoginService]
})
export class SocialLoginComponent implements OnInit {
  model: LoginModel;
  showLogin = false;
  _socialLoginTitle :string;
  constructor(
    private _router: Router,
    private _loginService: LoginService,
    private _logger: LoggerService,
    private _utilityService: UtilityService,
    private _toastrService: ToastrService,
    private _authService: AuthService,
    private _socialAuthService: SocialAuthService
) {
    this._logger.info('SocialLoginComponent : constructor ');
    this.model = new LoginModel();
    this.model.isAuthInitiated = false;
}

ngOnInit() {
  this._logger.info('SocialLoginComponent : ngOnInit ');
  this.showLogin = true;
  this._socialLoginTitle=Constants.socialLoginTitle;
  if (this._authService.isUserLoggedIn()) {
      this._router.navigate([Constants.uiRoutes.product]);
  }
}
  public socialSignIn(socialPlatform: string) {
    this._logger.info('SocialLoginComponent : socialSignIn ');
    let socialPlatformProvider;       
    this.model.isAuthInitiated = true;
    if (socialPlatform === Constants.LoginApi.Google) {
      socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
    }   
    if (socialPlatform === Constants.LoginApi.Facebook) {
        socialPlatformProvider = FacebookLoginProvider.PROVIDER_ID;
      }          
    this._socialAuthService.signIn(socialPlatformProvider).then(userData => {
        this._logger.info('SocialLoginComponent : signIn success');    
        this.socialUserAccess_token(userData);
      }         
    ,errorResponse=>{ 
        this._logger.error('SocialLoginComponent__socialAuthService.logOn : errorResponse ');
        this.resetModel();          
        this.model.isAuthInitiated = false;
        throw new HttpError(ErrorCode.AuthFailedInvalidAuthResponse, ErroNotificationType.Dialog, errorResponse);});
  }

  socialUserAccess_token(data) {  
    this._logger.info('SocialLoginComponent : socialUserAccess_token ');    
    var response={apiToken:{access_token:data.idToken,refresh_token:data.authToken},sessionId:data.id};
    this.processLoginRequest(response);     
 
  }

  processLoginRequest(response: any) {
    this._logger.info('SocialLoginComponent : processLoginRequest ');
    if (response) {
        localStorage.setItem(Constants.localStorageKeys.isLoggedIn, 'true');
        localStorage.setItem(Constants.localStorageKeys.apiToken, JSON.stringify(response.apiToken));
        localStorage.setItem(Constants.localStorageKeys.sessionId, response.sessionId);
        this._utilityService.redirectToURL(environment.appUrl);
    }
}

resetModel() {
    this._logger.info('SocialLoginComponent : resetModel ');
    this.model.emailAddress = '';
    this.model.password = '';
  }

}
