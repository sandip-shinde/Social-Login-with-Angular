import { Injectable } from '@angular/core';
import {
    CanActivate,
    Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';

import { Logger } from 'angular2-logger/core';

import { Constants } from '../infrastructure/constants';

import {
    ErrorCode,
    ErroNotificationType,
    ToastrMessageType,
    HttpError
} from '../../../core-module/index';

@Injectable()
export class AuthGuardService implements CanActivate {
    constructor(
        private _router: Router,
        private _logger: Logger
    ) {
        this._logger.info("AuthGuard : constructor ");
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        let url: string = state.url;

        this._logger.info("AuthGuard : canActivate");

        this.throwBusinessErrors(url);
        
        return true;
    }
    
    throwBusinessErrors(url: string): void {

        this._logger.info("AuthGuard : throwBusinessErrors");

        var isError: boolean = false;
        var errorCode: any;

        if (url.indexOf(Constants.businessExceptions.SessionExpired) != -1 || url.indexOf(Constants.businessExceptions.SessionKilled) != -1) {
            isError = true;
            errorCode = ErrorCode.UserSessionExpired;
        }
        else if (url.indexOf(Constants.businessExceptions.ErrorCode) != -1) {
            isError = true;
            errorCode = url.split("=")[1];
        }

        if (isError && errorCode != null) {
            setTimeout(() => {
                throw new HttpError(errorCode, ErroNotificationType.Toaster);
            }, 1000);
        }
    }
}