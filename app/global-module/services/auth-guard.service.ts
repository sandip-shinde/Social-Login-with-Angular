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

        // on shopresult page refresh, route to shop page
        if (this._router.routerState.snapshot.url == "" && url.indexOf(Constants.uiRoutes.shopresult) > 0) {
            this._router.navigate([Constants.uiRoutes.shop]);
        }

        return true;
    }
    
}