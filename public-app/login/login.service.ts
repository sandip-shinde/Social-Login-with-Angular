import { Injectable } from  '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Logger } from 'angular2-logger/core';

import { HttpService } from '../../core-module/index';

import { Constants } from '../shared/index';

@Injectable()
export class LoginService {
    
    constructor(
        private _http: HttpService,
        private _logger: Logger
    ) {
        this._logger.info("LoginService : constructor ");
    }

    logOn(request: any): Observable<any> {
        this._logger.info("LoginService : logOn ");
        return this._http.post(`${Constants.webApis.login}`, request);
    }    

}