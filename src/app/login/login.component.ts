import {
    Component,
    OnInit,
} from '@angular/core';

import { Router } from '@angular/router';

import { LoggerService } from '@core';

import {
    HttpError,
    ErrorCode,
    ToastrCode,
    ErroNotificationType,
    UtilityService,
    ToastrService,
    AuthService
} from '@core';

import { Constants } from '@shared';

import { LoginModel } from './login.model';

import { LoginService } from './login.service';

import { environment } from '@env';

@Component({
   moduleId: module.id,
   selector: 'login-app',
   templateUrl: 'login.component.html',
   providers: [LoginService]
})
export class LoginComponent implements OnInit {

   model: LoginModel;
   showLogin = false;

   constructor(
       private _router: Router,
       private _loginService: LoginService,
       private _logger: LoggerService,
       private _utilityService: UtilityService,
       private _toastrService: ToastrService,
       private _authServiece: AuthService
   ) {
       this._logger.info('LoginComponent : constructor ');
       this.model = new LoginModel();
       this.model.isAuthInitiated = false;
   }

   ngOnInit() {
       this._logger.info('LoginComponent : ngOnInit ');
       this.showLogin = true;

       if (this._authServiece.isUserLoggedIn()) {
           this._router.navigate([Constants.uiRoutes.product]);
       }
   }

   login() {

       this._logger.info('LoginComponent : login ');
       this.model.isAuthInitiated = true;
       if (!this.model.emailAddress) {
           this.model.isAuthInitiated = false;
           this._toastrService.showError(ToastrCode.EmptyEmailAddress);
       } else if (!this.model.password) {
           this.model.isAuthInitiated = false;
           this._toastrService.showError(ToastrCode.EmptyPassword);
       } else {
           this.model.isAuthInitiated = true;
           this._loginService.logOn({ UserName: this.model.emailAddress, Password: this.model.password })
               .subscribe(
               (successResponse) => {
                   this._logger.info('LoginComponent_loginService.logOn : successResponse ');
                   const response = successResponse.json();
                   this.model.isAuthInitiated = false;
                   this.processLoginRequest(response);
               },
               (errorResponse) => {
                   this.resetModel();
                   this._logger.error('LoginComponent_loginService.logOn : errorResponse ');
                   this.model.isAuthInitiated = false;
                   throw new HttpError(ErrorCode.AuthFailedInvalidAuthResponse, ErroNotificationType.Dialog, errorResponse);
               });
       }
   }

   processLoginRequest(response: any) {
       this._logger.info('LoginComponent : processLoginRequest ');
       if (response) {

           localStorage.setItem(Constants.localStorageKeys.isLoggedIn, 'true');
           localStorage.setItem(Constants.localStorageKeys.apiToken, JSON.stringify(response.apiToken));

           this._utilityService.redirectToURL(environment.appUrl);
       }
   }

   resetModel() {
       this._logger.info('LoginComponent : resetModel ');
       this.model.emailAddress = '';
       this.model.password = '';
   }
}