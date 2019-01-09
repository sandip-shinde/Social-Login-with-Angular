import {
    Component,
    OnInit
} from '@angular/core';

import { Logger } from 'angular2-logger/core';

import { SharedDataService } from '../global-module/index';

import { Constants } from '../shared-module/index';

import {
    ToastrMessageType,
    ToastrService,
    ToastrCode
} from '../../core-module/index';

import { HomeService } from './home.service';

@Component({
    moduleId: module.id,
    selector: 'home-app',
    templateUrl: 'home.component.html'
})
export class HomeComponent implements OnInit {

    constructor(
        private _logger: Logger,
        private _sharedDataService: SharedDataService,
        private _toastrService: ToastrService,
        private _homeService: HomeService
    ) {
        this._logger.info("HomeComponent : constructor ");
    }

    ngOnInit() {
        this._logger.info("HomeComponent : ngOnInit ");    
    }  
}