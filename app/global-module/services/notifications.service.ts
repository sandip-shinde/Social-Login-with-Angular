import {
    Injectable,
    Inject,
    ElementRef
} from '@angular/core';

import { Logger } from 'angular2-logger/core';
import { Subject } from 'rxjs/Subject';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { HttpService } from '../../../core-module/index';
import { FocusManagerModel } from '../focus-manager/index';

@Injectable()
export class NotificationService {

    productAddedToCartNotification: Subject<null> = new Subject<null>();
    productAddedToCartFromDialogNotification: Subject<null> = new Subject<null>();
    disableUINotification: Subject<null> = new Subject<null>();
    contentLoadedNotification: Subject<FocusManagerModel> = new Subject<FocusManagerModel>();

    constructor(
        private _http: HttpService,
        private _logger: Logger
    ) {
        this._logger.info("NotificationService : constructor");
    }
   
    notifyProductAddedToCart() {
        this._logger.info("NotificationService : notifyNonCatalogProductAddedToCart");
        this.productAddedToCartNotification.next();
    }

    notifyProductAddedToCartFromDialog() {
        this._logger.info("NotificationService : notifyNonCatalogProductAddedToCart");
        this.productAddedToCartFromDialogNotification.next();
    }
    
    notifyEventContentLoaded(focusManagerModel?: FocusManagerModel) {
        this._logger.info("NotificationService : notifyEventContentLoaded");
        this.contentLoadedNotification.next(focusManagerModel);
    }

    notifyDisableUI() {
        this._logger.info("NotificationService : notifyDisableUI");
        this.disableUINotification.next();
    }
}