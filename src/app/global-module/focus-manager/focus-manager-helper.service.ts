import {
    Injectable,
    Inject,
    ElementRef
} from '@angular/core';

import { Logger } from 'angular2-logger/core';

import { NotificationService } from '../services/index';
import { FocusManagerModel } from './index';

@Injectable()
export class FocusManagerHelperService {
    constructor(
        private _logger: Logger,
        private _notificationService: NotificationService
    ) {
        this._logger.info("FocusManagerHelperService : constructor ");
    }

    public setPopupFocusIndexes = (containerElement: ElementRef, isChildClosing?: boolean): void => {
        this._logger.info("FocusManagerHelperService : setPopupFocusIndexes");  
        var focusManagerData = new FocusManagerModel();
        if (isChildClosing !== undefined && isChildClosing === true) {
            focusManagerData.setPreviousActiveIndex = false;
            focusManagerData.restorePreviousActiveIndex = true;
        }
        else {
            focusManagerData.setPreviousActiveIndex = true;
        }
        focusManagerData.element = containerElement;
        this._notificationService.notifyEventContentLoaded(focusManagerData);       
    };

    public setFocusIndexes = (containerElement: ElementRef, retainCurrentActiveIndex: boolean): void => {
        this._logger.info("FocusManagerHelperService : setFocusIndexes");
        var focusManagerData = new FocusManagerModel();
        focusManagerData.retainCurrentActiveIndex = retainCurrentActiveIndex;
        focusManagerData.element = containerElement;
        this._notificationService.notifyEventContentLoaded(focusManagerData);
    };

    public resetFocusIndexes = (): void => {
        this._logger.info("FocusManagerHelperService : resetFocusIndexes"); 
        var focusManagerData = new FocusManagerModel();
        focusManagerData.setPreviousActiveIndex = false;
        focusManagerData.restorePreviousActiveIndex = true;
        this._notificationService.notifyEventContentLoaded(focusManagerData);
    };

    public rebuildFocusIndexes = (): void => {
        this._logger.info("FocusManagerHelperService : rebuildFocusIndexes"); 
        var focusManagerData = new FocusManagerModel();
        focusManagerData.setPreviousActiveIndex = false;
        this._notificationService.notifyEventContentLoaded(focusManagerData);
    };

    public setFocusToElement = (elementToFocus: ElementRef): void => {
        elementToFocus.nativeElement.focus();
    };
};