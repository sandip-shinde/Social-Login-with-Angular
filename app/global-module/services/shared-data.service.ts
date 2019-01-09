import {
    Injectable,
    Inject
} from  '@angular/core';

import {    
    RequestOptions,
    URLSearchParams
} from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import { Logger } from 'angular2-logger/core';

import { Constants } from '../infrastructure/constants';

import { SharedData } from './index';

import {
    AuthService,
    HttpError,
    ErrorCode,
    ErroNotificationType,
    HttpService,
    UtilityService
} from '../../../core-module/index';

import { Environment } from '../../environment';

@Injectable()
export class SharedDataService {

    public _sharedData: SharedData;        
    public isDisableUIElements: boolean;

    constructor(
        private _logger: Logger,
        private _authService: AuthService,
        private _https: HttpService,
        private _utilityService: UtilityService
    ) {
        this._logger.info("SharedDataService : constructor ");
    }


    populateCommonData(): Promise<any> {

        this._logger.info("SharedDataService : populateCommonData ");

        if (!this._authService.isUserLoggedIn())
            return;

        var promise = this._https.get(`${Constants.webApis.getSharedData}`)
            .toPromise();

        promise.then(
            successResponse => {
                this._logger.info("SharedDataService : populateCommonData : successResponse " + successResponse);
                this._sharedData = successResponse.json();    
                this._sharedData.sessionId = localStorage.getItem(Constants.localStorageKeys.sessionId);                
            })
            .catch(
            errorResponse => {
                this._logger.info("SharedDataService : populateCommonData : errorResponse " + errorResponse);

                var url: string = Environment.appUrl + "?" + Constants.queryString.SessionExpired;
                this._utilityService.redirectToURL(url);
            });

        return promise;

    }
}

