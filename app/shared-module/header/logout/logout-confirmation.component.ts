import {
    Component,
    ViewChild,
    ViewEncapsulation,
    Output,
    EventEmitter,
    ChangeDetectionStrategy,
    ElementRef
} from '@angular/core';

import { Router } from '@angular/router';
import { Logger } from 'angular2-logger/core';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';

@Component({
    moduleId: module.id,
    changeDetection: ChangeDetectionStrategy.OnPush,
    selector: 'logout-confirmation',
    templateUrl: 'logout-confirmation.component.html',
    encapsulation: ViewEncapsulation.None
})
export class LogoutConfirmationComponent {
    @ViewChild('modal') modalComp: ModalComponent;
    @ViewChild('logoutContainer') container: ElementRef;
    @Output() onLogoutConfirmation = new EventEmitter<boolean>();

    constructor(
        private router: Router,
        private _logger: Logger
    ) {
        this._logger.info("LogoutConfirmationComponent : ngOnInit ");
    }

    showConfirmation() {
        this._logger.info("LogoutConfirmationComponent : showConfirmation ");
        this.modalComp.open();
    }

    closeAndInstructLogoutToParent() {
        this._logger.info("LogoutConfirmationComponent : closeAndInstructLogoutToParent ");
        this.onLogoutConfirmation.emit(true);
    }

    dismissModal() {
    }
}