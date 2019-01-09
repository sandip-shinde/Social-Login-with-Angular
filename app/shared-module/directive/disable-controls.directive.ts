import {
    Directive,
    ElementRef,
    HostListener,
    Input,
    Renderer,
    AfterViewInit
} from '@angular/core';

import { TranslateService } from 'ng2-translate';
import { Logger } from 'angular2-logger/core';
import {
    NotificationService,
    SharedDataService,
    SharedData
} from '../../global-module/index';


@Directive({
    selector: '[disable-controls]'
})
export class DisableControls implements AfterViewInit {
    parentElement: ElementRef;
    modelHeader: string;
    reset: string;

    constructor(private el: ElementRef,
        private renderer: Renderer,
        private _notificationService: NotificationService,
        private _sharedDataService: SharedDataService,
        private _translateService: TranslateService,
        private _logger: Logger,
    ) {
        this._logger.info("DisableControls : constructor ");
        this.parentElement = el;

        this._translateService.get('SHARED.DISABLECONTROLS.ModalHeader').subscribe((resource: any) => {
            this.modelHeader = resource;
        });
        this._translateService.get('SHARED.DISABLECONTROLS.ResetLink').subscribe((resource: any) => {
            this.reset = resource;
        });

    }

    ngAfterViewInit() {
        this._logger.info("DisableControls : ngAfterViewInit ");
        this._notificationService.disableUINotification.subscribe(() => {
            this.disableAllElements(this.parentElement.nativeElement);
        });
    }


    private disableAllElements(currentElement: any): void {
        this._logger.info("DisableControls : disableAllElements ");
        if (currentElement != undefined && currentElement.childElementCount != undefined && currentElement.childElementCount > 0)
        {
            for (var i = 0; i < currentElement.childElementCount; i++)
            {
                if (currentElement.children[i].tagName != this.modelHeader)
                {
                    if (currentElement.children[i].innerText != this.reset && currentElement.children[i].value != this.reset)
                    {
                        if (this._sharedDataService.isDisableUIElements == true)
                            currentElement.children[i].setAttribute("disabled", "true");
                        else
                            currentElement.children[i].removeAttribute("disabled");
                    }
                    else {
                        if (this._sharedDataService.isDisableUIElements == true)
                            currentElement.children[i].setAttribute("style", "visibility: hidden");
                        else
                            currentElement.children[i].setAttribute("style", "visibility: visible");
                    }
                    this.disableAllElements(currentElement.children[i]);
                }
            }
        }
    }
}