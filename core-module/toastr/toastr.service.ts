import {
    Injectable
} from '@angular/core';

import { Logger } from 'angular2-logger/core';

import {
    ErroNotificationType,
    HttpError,
    ErrorCode,
    ToastrMessageType,
    ToastrMessage,
    ToastrCode
} from '../index';

import { ConfigurationSettings } from '../infrastructure/index';

import { ToastrMessageHelperService } from './message-helper.service';

@Injectable()
export class ToastrService {

    _toastrMessage: string;
    _messageType: ToastrMessageType;
    _notificationType: ErroNotificationType;

    showToastrError: (errorMessage: string) => void;
    showToastrSuccess: (successMessage: string) => void;
    showToastrWarning: (warningMessage: string) => void;
    showToastrInformation: (informationMessage: string) => void;
    showToastrCustom: (customMessage: string) => void;

    constructor(private _logger: Logger,
        private _toastrMessageHelperService: ToastrMessageHelperService
    ) {
        this._logger.info("ToastrService : constructor ");
    }

    public showErrorToastr(errorCode: ErrorCode, messageParams: any) {
        this._logger.info("ToastrService : showErrorToastr ");
        
        var toastrMessage = this.getToastrMessage(errorCode, messageParams);
        this.showToastrMessage(toastrMessage.messageType, toastrMessage.message);
    }

    public showToastr(toastrCode: ToastrCode, messageParams: any) {
        this._logger.info("ToastrService : showToastr ");

        var toastrMessage = this.getToastrMessage(toastrCode, messageParams);
        this.showToastrMessage(toastrMessage.messageType, toastrMessage.message);
    }

    public showToastrMessage(messageType: ToastrMessageType, message: string) {
        this._logger.info("ToastrService : showToastrMessage ");
        switch (messageType) {
            case ToastrMessageType.Error:
                this.showToastrError(message);
                break;
            case ToastrMessageType.Information:
                this.showToastrInformation(message);
                break;
            case ToastrMessageType.Success:
                this.showToastrSuccess(message);
                break;
            case ToastrMessageType.Warning:
                this.showToastrWarning(message);
                break;
            case ToastrMessageType.Custom:
                this.showToastrCustom(message);
                break;
        }
        if (messageType != ToastrMessageType.Information) {
            this._logger.log(message);
        }
    }

    private getToastrMessage(toastrCode: any, messageParams: any): ToastrMessage {
        this._logger.info("ToastrService : getToastrMessage ");
        return this._toastrMessageHelperService.getFormattedToastrMessage(toastrCode, messageParams);
    }
}