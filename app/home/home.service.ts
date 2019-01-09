import { Injectable } from '@angular/core';

import { Logger } from 'angular2-logger/core';

import { Constants } from '../shared-module/index';

import { Observable } from 'rxjs/Observable';
import { HttpService } from '../../core-module/index';

@Injectable()
export class HomeService {

    constructor(
        private _http: HttpService,
        private _logger: Logger
    ) {
        this._logger.info("HomeService : constructor ");
    }

    
}