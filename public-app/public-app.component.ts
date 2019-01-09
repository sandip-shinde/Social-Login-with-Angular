import { Component          } from '@angular/core';
import {
    Event as RouterEvent,
    Router
} from '@angular/router';

import { Logger             } from 'angular2-logger/core';
import { TranslateService   } from 'ng2-translate';

import {    
    ConfigurationSettings,
    NotificationService
} from './shared/index';

@Component({
    moduleId: module.id,
    selector: 'app',
    template: ` <error-dialog></error-dialog>
                <toastr></toastr>
                <div (window:resize)="onWindowResized($event)">
                    <public-app></public-app>
                </div>
              `
})
export class PublicAppComponent {
    
    constructor(
        private _logger: Logger,
        private _translate: TranslateService,
        private _router: Router,        
        private _notificationService: NotificationService
    ) {

        this._logger.info("PublicAppComponent : constructor ");

        this._logger.level = ConfigurationSettings.LogLevel;

        _translate.addLangs(ConfigurationSettings.supportedBrowserLanguages);
        _translate.setDefaultLang(ConfigurationSettings.fallbackBrowserLanguage);

        let browserLang = _translate.getBrowserLang();

        this._logger.info("PublicAppComponent : constructor => Current browserLang Is :" + browserLang);

        let languageConfiguredForApplication = browserLang.match(ConfigurationSettings.supportedBrowserLanguages.join("|")) ? browserLang : ConfigurationSettings.fallbackBrowserLanguage;

        _translate.use(languageConfiguredForApplication);

        this._logger.info("PublicAppComponent : constructor => Application language is set to :" + languageConfiguredForApplication);
        
    }

    onWindowResized(event: any) {
        this._logger.info("PublicAppComponent : onWindowResized");
        if (this._router.url == "/")
            this._notificationService.windowResizeNotification.next();
    }

    ngOnInit() {        
        this._logger.info("PublicAppComponent : ngOnInit() ");
    }

}