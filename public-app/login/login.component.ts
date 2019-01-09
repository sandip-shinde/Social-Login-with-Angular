 import {
     Component,
     OnInit,
 } from  '@angular/core';

import { Router } from '@angular/router';
import { Logger } from 'angular2-logger/core';

import { TranslateService } from 'ng2-translate';

 import {
     HttpError,
     ErrorCode,
     ToastrCode,
     ErroNotificationType,
     UtilityService,
     ToastrService
} from '../../core-module/index';

import { Constants } from '../shared/index';

import {
     LoginModel,
     LoginService
 } from './index';

import { Environment } from '../environment';

@Component({
    moduleId: module.id,
    selector: 'login-app',
    templateUrl: 'login.component.html',
    providers: [LoginService]
})
export class LoginComponent implements OnInit {
    
    model: LoginModel;
    showLogin: boolean = false;

    constructor(
        private _router: Router,
        private _loginService: LoginService,
        private _logger: Logger,
        private _utilityService: UtilityService,
        private _toastrService: ToastrService
    ) {
        this._logger.info("LoginComponent : constructor ");
        this.model = new LoginModel();
        this.model.isAuthInitiated = false;
    }

    ngOnInit() {
        this._logger.info("LoginComponent : ngOnInit ");        
        this.showLogin = true;        
    }
    
    login() {

        this._logger.info("LoginComponent : login ");
        this.model.isAuthInitiated = true;
        if (!this.model.emailAddress) {
            this.model.isAuthInitiated = false;
            this._toastrService.showToastr(ToastrCode.EmptyEmailAddress, null);
        }
        else if (!this.model.password) {
            this.model.isAuthInitiated = false;
            this._toastrService.showToastr(ToastrCode.EmptyPassword, null);
        }
        else {
            this.model.isAuthInitiated = true;
            this._loginService.logOn({ UserName: this.model.emailAddress, Password: this.model.password })
                .subscribe(
                (successResponse) => {
                    this._logger.info("LoginComponent_loginService.logOn : successResponse ");
                    var response = successResponse.json();
                    response.code = "";
                    this.model.isAuthInitiated = false;
                    this.processLoginRequest(response);                    
                },
                (errorResponse) => {
                    this.resetModel();
                    this._logger.error("LoginComponent_loginService.logOn : errorResponse ");
                    this.model.isAuthInitiated = false;
                    throw new HttpError(ErrorCode.AuthFailedInvalidAuthResponse, ErroNotificationType.Dialog, errorResponse);
                });
        }
    }

    processLoginRequest(response: any) {
        this._logger.info("LoginComponent : processLoginRequest ");
        if (response) {

            localStorage.setItem(Constants.localStorageKeys.isLoggedIn, "true");
            localStorage.setItem(Constants.localStorageKeys.apiToken, JSON.stringify(response.apiToken));            
            localStorage.setItem(Constants.localStorageKeys.sessionId, response.sessionId);

            this._utilityService.redirectToURL(Environment.appUrl);
        }
    }
    
    resetModel() {
        this._logger.info("LoginComponent : resetModel ");
        this.model.emailAddress = "";
        this.model.password = "";
    }
}