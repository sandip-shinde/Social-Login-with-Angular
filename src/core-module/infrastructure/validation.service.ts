import { Injectable } from  '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Logger } from 'angular2-logger/core';
 
@Injectable()
export class ValidationService {
    constructor(
        private _logger: Logger
    ) {
        this._logger.info("ValidationService : constructor ");
    }

    public isNumberKey(event: any): boolean {
        this._logger.info("ValidationService : isNumberKey ");
        var charCode = (event.which) ? event.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && !event.ctrlKey)
            return false;

        return true;
    }

    public isEnterKey(event: any): boolean {
        this._logger.info("ValidationService : isEnterKey ");
        return ((event.keyCode || event.which) == 13);
    }

    public regExpValidator = (regExPattern: string, valueToValidate: string, flags?: string): boolean => {
        this._logger.info("ValidationService: regExpValidator");
        var flags = flags || ''; //set the regex flags if supplied (optional)
        var regEx: RegExp = new RegExp(regExPattern, flags);
        return regEx.test(valueToValidate); // test and set the validity after update. 
    }
}