import { Injectable } from '@angular/core';

import { Logger } from 'angular2-logger/core';
import { Subject } from 'rxjs/Subject';


@Injectable()
export class NotificationService {
    
    windowResizeNotification: Subject<null> = new Subject<null>();

    constructor(
        private _logger: Logger
    ) {
        this._logger.info("NotificationService : constructor");
    }
    
    notifyWindowResized() {
        this._logger.info("NotificationService : notifyWindowResized");
        this.windowResizeNotification.next();
    }
}