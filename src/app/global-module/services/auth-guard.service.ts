import { Injectable } from '@angular/core';
import {
    CanActivate,
    Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';

import {
    LoggerService,
    AuthService
} from '@core';

@Injectable()
export class AuthGuardService implements CanActivate {
    constructor(
        private _router: Router,
        private _logger: LoggerService,
        private _authService : AuthService
    ) {
        this._logger.info('AuthGuard : constructor ');
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const url: string = state.url;

        this._logger.info('AuthGuard : canActivate');

        if(!this._authService.isUserLoggedIn()) {
            this._router.navigate(['']);
            return false;
        }

        return true;
    }
}