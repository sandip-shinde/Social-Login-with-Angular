import { Component          } from '@angular/core';
import { Logger             } from 'angular2-logger/core';
import { TranslateService   } from 'ng2-translate';

import {
    Event as RouterEvent,
    Router,
    NavigationStart,
    NavigationEnd,
} from '@angular/router';

import {    
    NotificationService,
    SharedDataService
} from './global-module/index';

import {
    ConfigurationSettings,
    Constants
} from './shared-module/index';

import {
    AuthService
} from '../core-module/index';

@Component({
    moduleId: module.id,
    selector: 'app',
    template: `<a href="javascript:void(0);" onclick="document.location.hash='main-content-area';" class="skip-nav">Skip to main content</a>
                <error-dialog></error-dialog>
                <toastr></toastr>
                <div *ngIf="isUserLoggedIn" (window:resize)="onWindowResized($event)">
                    <home-app focus-manager></home-app>
                </div>
              `
})
export class AppComponent {

    isUserLoggedIn: boolean = false;

    constructor(
        private _logger: Logger,
        private _translate: TranslateService,
        private _router: Router,
        private _authService: AuthService,
        private _notificationService: NotificationService,
        private _sharedDataService: SharedDataService
    ) {

        this._logger.info("AppComponent : constructor ");

        this._logger.level = ConfigurationSettings.LogLevel;

        this._logger.info("AppComponent : constructor => language configured");

        _translate.addLangs(ConfigurationSettings.supportedBrowserLanguages);
        _translate.setDefaultLang(ConfigurationSettings.fallbackBrowserLanguage);

        let browserLang = _translate.getBrowserLang();

        this._logger.info("AppComponent : constructor => Current browserLang Is :" + browserLang);

        let languageConfiguredForApplication = browserLang.match(ConfigurationSettings.supportedBrowserLanguages.join("|")) ? browserLang : ConfigurationSettings.fallbackBrowserLanguage;

        _translate.use(languageConfiguredForApplication);

        this._logger.info("AppComponent : constructor => Application language is set to :" + languageConfiguredForApplication);

    }

    ngOnInit() {
        this.isUserLoggedIn = this._authService.isUserLoggedIn();
        this._logger.info("AppComponent : ngOnInit() ");
    }

    onWindowResized(event : any){

    }

}