import {
    ErrorHandler,
    Injectable,
    Inject
} from '@angular/core';

import { Logger } from 'angular2-logger/core';

import {    
    AuthService
} from '../extensions/index';

import {
    Constants,
    ConfigurationSettings,
    UtilityService,
    EnvironmentConfig
} from '../infrastructure/index';

import { SpinnerService } from '../spinner/spinner.service';

import { GlobalErrorLoggingService } from "./index";

export class LoggingErrorHandlerOptions {
    isRethrowError: boolean;
    isUnwrapError: boolean;
    isLogErrorToConsole: boolean;
    isSendErrorToServer: boolean;
    isShowErrorDialog: boolean;
}

@Injectable()
export class GlobalErrorHandlerComponent implements ErrorHandler {

    private options: LoggingErrorHandlerOptions;

    constructor(
        private _globalErrorLoggingService: GlobalErrorLoggingService,
        _options: LoggingErrorHandlerOptions,
        private _logger: Logger,
        private _spinner: SpinnerService,
        private _utilityService: UtilityService,
        private _authService: AuthService,
        private _config : EnvironmentConfig
    ) {
        this._logger.info("ErrorHandler : constructor");
        this.options = _options;
    }

    public handleError(error: any): void {

        var url: string = this._config.appUrl + "?" + Constants.queryString.SessionExpired;
        
        try {
            this._logger.info("ErrorHandler : handleError()");

            var sessionId = localStorage.getItem(Constants.localStorageKeys.sessionId);

            if (this._authService.isUserLoggedIn() &&  (sessionId == null || sessionId == undefined || sessionId == "") ) {
                this._utilityService.redirectToURL(url);
                return;
            }
          
            if (error && error.error && error.error.status == 0) {     
                 return;
            }

            if (error && error.error && error.error.status == 405) {
                this._utilityService.redirectToURL(url);
                return;
            }

            this._spinner.stop();
            this.options.isUnwrapError
                ? this._globalErrorLoggingService.logError(this.findOriginalError(error), this.options.isLogErrorToConsole, this.options.isSendErrorToServer)
                : this._globalErrorLoggingService.logError(error, this.options.isLogErrorToConsole, this.options.isSendErrorToServer);
        }
        catch (loggingError) {
            this._logger.error("Error when trying to log error to", this._globalErrorLoggingService);

            this._utilityService.redirectToURL(url);
            return;

        }

        if (this.options.isRethrowError) {
            throw (error);
        }
    }

    private findOriginalError(error: any): any {
        this._logger.info("ErrorHandler : findOriginalError()");

        while (error && error.originalError) 
            error = error.originalError;

        return (error);
    }
}