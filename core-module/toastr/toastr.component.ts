import {
    Inject,
    Component,
    ViewContainerRef
} from '@angular/core';

import { Router } from  '@angular/router';
import { Logger } from 'angular2-logger/core';
import { ToastrService } from './index';
import { Constants } from '../infrastructure/constants';
import {
    AutoCloseToastrOptions,
    CustomToastrOptions,
    SystemMessageToastrOptions
} from '../infrastructure/configuration-settings'

import {
    ToastsManager,
    Toast
} from 'ng2-toastr/ng2-toastr';

@Component({
    moduleId: module.id,
    selector: 'toastr',
    template: '<div></div>'
})
export class ToastrComponent {

    constructor(
        private router: Router,
        private _logger: Logger,
        private _globalToastrService: ToastrService,     
        private _toastrMgr: ToastsManager,
        private _vRef: ViewContainerRef
    ) {

        //breaking change : https://github.com/PointInside/ng2-toastr#breaking-change-solution-for-angular-v22x
        this._toastrMgr.setRootViewContainerRef(_vRef);
        this._logger.info("GlobalToastrComponent : ngOnInit");
        _globalToastrService.showToastrError = this.showToastrError.bind(this);
        _globalToastrService.showToastrSuccess = this.showToastrSuccess.bind(this);
        _globalToastrService.showToastrWarning = this.showToastrWarning.bind(this);

        _globalToastrService.showToastrInformation = this.showToastrInformation.bind(this);
        _globalToastrService.showToastrCustom = this.showCustomToastr.bind(this);
    }

    showToastrError(errorMessage: string) {
        this._logger.info("ToastrComponent : showToastrError");
        this._toastrMgr.error(errorMessage);
    }

    showToastrSuccess(successMessage: string) {
        this._logger.info("ToastrComponent : showToastrSuccess");
        this._toastrMgr.success(successMessage, "", AutoCloseToastrOptions )
    }

    showToastrWarning(warningMessage: string) {
        this._logger.info("ToastrComponent : showToastrWarning");
        this._toastrMgr.warning(warningMessage, null, SystemMessageToastrOptions);
        this._toastrMgr.onClickToast()
            .subscribe(toast => {
                this._toastrMgr.clearToast(toast);
            });
    }

    showToastrInformation(informationMessage: string) {
        this._logger.info("ToastrComponent : showToastrInformation");
        this._toastrMgr.info(informationMessage, "", AutoCloseToastrOptions )
    }

    showCustomToastr(informationMessage: string) {
        this._logger.info("ToastrComponent : showCustomToastr");
        this._toastrMgr.custom(informationMessage, null, CustomToastrOptions )
    }
}
