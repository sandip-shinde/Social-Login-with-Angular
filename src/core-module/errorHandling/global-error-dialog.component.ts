﻿import {
    Component,
    ViewChild,
    ViewEncapsulation,
    Output,
    EventEmitter
} from '@angular/core';

import { Router } from '@angular/router';
import { LoggerService } from '../services/logger.service';
import { BsModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { GlobalErrorLoggingService } from './global-error-logging.service';

@Component({
    moduleId: module.id,
    selector: 'error-dialog',
    templateUrl: 'global-error-dialog.component.html',
    encapsulation: ViewEncapsulation.None
})
export class GlobalErrorDialogComponent {

    @ViewChild('modal')
    _modal: BsModalComponent;
    _dialogTitle: string;
    _message: string;
    _isShowSecondaryButton: boolean;
    _primaryButtonText: string;
    _secondaryButtonText: string;
    _isLogoutOnPrimaryButtonEvent: boolean;

    constructor(
        private router: Router,
        private _logger: LoggerService,
        private _globalErrorLoggingService: GlobalErrorLoggingService
    ) {
        this._logger.info('GlobalErrorDialogComponent : ngOnInit ');
        _globalErrorLoggingService.showErrorDialog = this.showErrorDialog.bind(this);
    }


    showErrorDialog(errorDialogTitle: string, customErrorMessage: string, primaryButtonText: string, isLogoutOnPrimaryButtonEvent: boolean, isShowSecondaryButton: boolean, secondaryButtonText: string) {
        this._logger.info('GlobalErrorDialogComponent : showErrorDialog ');
        this._dialogTitle = errorDialogTitle;
        this._message = customErrorMessage;
        this._isShowSecondaryButton = isShowSecondaryButton;
        this._primaryButtonText = primaryButtonText;
        this._secondaryButtonText = secondaryButtonText;
        this._isLogoutOnPrimaryButtonEvent = isLogoutOnPrimaryButtonEvent;
        this._modal.open();
    }

    logout() {
        this._logger.info('GlobalErrorDialogComponent : logout ');
    }

    initDialogData() {
        this._logger.info('GlobalErrorDialogComponent : initDialogData ');
    }
}
