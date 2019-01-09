import {
    Injectable,
    Inject
} from '@angular/core';

import {
    ErroNotificationType,
    HttpError,
    ErrorCode,
    ToastrMessageType,
    ToastrMessage
} from '../index';

import { TranslateService } from 'ng2-translate';
import { Logger } from 'angular2-logger/core';
import { Constants } from '../infrastructure/index';
import { ToastrService } from './toastr.service';

@Injectable()
export class ToastrMessageHelperService {
    constructor(
        private _logger: Logger,
        private _translate: TranslateService
    ) {
        this._logger.info("ToastrMessageHelperService : constructor ");
    }

    public getFormattedToastrMessage = (toastrCode: any, messageParams: any): ToastrMessage => {
        this._logger.info("ToastrMessageHelperService : getFormattedToastrMessage");
        var toastrKey: string = 'MESSAGES.Toastr.';
        var toastrMessage: ToastrMessage = new ToastrMessage();

        if (messageParams == null) {
            this._translate.get(toastrKey + toastrCode)
                .subscribe((successResponse) => {
                    this._logger.info("ToastrMessageHelperService : getFormattedToast : Success");
                    toastrMessage.message = successResponse.message;
                    toastrMessage.messageType = <ToastrMessageType>successResponse.messageType;
                }, (errorResponse) => {
                    this._logger.info("ToastrMessageHelperService : getFormattedToastrMessage : Error");
                });
        }
        else {
            this._translate.get(toastrKey + toastrCode)
                .subscribe((successResponse) => {
                    this._logger.info("ToastrMessageHelperService : getFormattedToastrMessage : Success");
                    toastrMessage.messageType = <ToastrMessageType>successResponse.messageType;
                    this._translate.get(toastrKey + toastrCode + '.message', messageParams)
                        .subscribe((transformedMessageResponse) => {
                            toastrMessage.message = transformedMessageResponse;
                        });
                }, (errorResponse) => {
                    this._logger.info("ToastrMessageHelperService : getFormattedToastrMessage : Error");
                });
        }
        return toastrMessage;
    };
};