import {
    Component,
    OnInit,
    ChangeDetectionStrategy,
    ChangeDetectorRef
} from  '@angular/core';

import { Logger } from 'angular2-logger/core';

import { ConfigurationSettings } from '../infrastructure/index';

import { SharedDataService } from '../../global-module/index';

import { UtilityService } from '../../../core-module/index';

import { FooterService } from './footer.service';

@Component({
    moduleId: module.id,
    changeDetection: ChangeDetectionStrategy.OnPush,
    selector: 'footer',
    templateUrl: 'footer.component.html',
    providers: [FooterService]
})
export class FooterComponent implements OnInit {
    model: string = "";
    
    constructor(
        private _logger: Logger,
        private _utilityService: UtilityService,
        private _changeRef: ChangeDetectorRef,
        private _footerService: FooterService,
        private _sharedDataService: SharedDataService
    ) {
        this._logger.info("FooterComponent : constructor ");
    }

    ngOnInit() {
        this._logger.info("FooterComponent : ngOnInit");        
    }

}