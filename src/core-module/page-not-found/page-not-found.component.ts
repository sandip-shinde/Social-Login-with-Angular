import { Component } from '@angular/core';
import { Logger } from 'angular2-logger/core';

@Component({
    moduleId: module.id,
    selector: 'page-not-found',
    template: `<div class="empty-page">page not found</div>`
})
export class PageNotFoundComponent{

    constructor(        
        private _logger: Logger
    ) {
        this._logger.info("PageNotFoundComponent : constructor ");
    }

} 