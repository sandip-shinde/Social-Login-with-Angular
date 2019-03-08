import {
    Injectable
} from '@angular/core';

import {
    ToastrMessageType,
    ToastrMessage
} from '../extensions/http-error.model';

import {TranslateService} from '@ngx-translate/core';
import { LoggerService } from '../services/logger.service';

@Injectable()
export class ToastrMessageHelperService {
    constructor(
        private _logger: LoggerService,
        private _translate: TranslateService
    ) {
        this._logger.info('ToastrMessageHelperService : constructor ');
    }

    public getFormattedToastrMessage = (toastrCode: any, messageParams: any): ToastrMessage => {
        this._logger.info('ToastrMessageHelperService : getFormattedToastrMessage');
        const toastrKey = 'MESSAGES.Toastr.';
        const toastrMessage: ToastrMessage = new ToastrMessage();

        if (messageParams == null) {
            this._translate.get(toastrKey + toastrCode)
                .subscribe((successResponse) => {
                    this._logger.info('ToastrMessageHelperService : getFormattedToast : Success');
                    toastrMessage.message = successResponse.message;
                    toastrMessage.messageType = <ToastrMessageType>successResponse.messageType;
                }, (errorResponse) => {
                    this._logger.info('ToastrMessageHelperService : getFormattedToastrMessage : Error');
                });
        } else {
            this._translate.get(toastrKey + toastrCode)
                .subscribe((successResponse) => {
                    this._logger.info('ToastrMessageHelperService : getFormattedToastrMessage : Success');
                    toastrMessage.messageType = <ToastrMessageType>successResponse.messageType;
                    this._translate.get(toastrKey + toastrCode + '.message', messageParams)
                        .subscribe((transformedMessageResponse) => {
                            toastrMessage.message = transformedMessageResponse;
                        });
                }, (errorResponse) => {
                    this._logger.info('ToastrMessageHelperService : getFormattedToastrMessage : Error');
                });
        }
        return toastrMessage;
    }
}
