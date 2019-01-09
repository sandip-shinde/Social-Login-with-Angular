import {
    Component,
    OnInit
} from '@angular/core';

import { Logger } from 'angular2-logger/core';

@Component({
    moduleId: module.id,
    selector: 'public-app',
    templateUrl: 'public.component.html'
})
export class PublicComponent implements OnInit {
    
    constructor(
        private _logger: Logger
    ) {
        this._logger.info("PublicComponent : constructor ");
    }

    ngOnInit() {
        this._logger.info("PublicComponent : ngOnInit ");
    }
   
}