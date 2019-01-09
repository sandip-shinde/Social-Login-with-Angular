import {
    Injectable,
    Inject
} from '@angular/core';

import {
    Response,
    RequestOptions,
    URLSearchParams
} from '@angular/http';

import { Observable } from 'rxjs/Observable';
import { Logger } from 'angular2-logger/core';

import { Constants } from '../infrastructure/index';

import {
    HttpService
} from '../../../core-module/index';

@Injectable()
export class FooterService {
    
    constructor(
        private _http: HttpService,
        private _logger: Logger
    ) {
        this._logger.info("FooterService : constructor ");
    }

    getFooterSupportContactInfo(entityId: number): Observable<any> {

        this._logger.info("FooterService : getFooterSupportContactInfo ");

        return Observable.of("support@test.company");
    }
}