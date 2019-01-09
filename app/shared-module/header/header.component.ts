import {
    Component,
    OnInit,
    ViewChild,
    ChangeDetectionStrategy,
    ElementRef
} from '@angular/core';

import { Logger } from 'angular2-logger/core';
import { Router } from '@angular/router';

import {
    SharedData,
    SharedDataService,
    NotificationService
} from '../../global-module/index';

import {
    ConfigurationSettings,    
    Constants
} from '../infrastructure/index';

import {
    LogoutConfirmationComponent
} from '../header/index';

import {
    HttpError,
    ErrorCode,
    ErroNotificationType,
    UtilityService,
    AuthService
} from '../../../core-module/index';

import { Environment } from '../../environment';

@Component({
    moduleId: module.id,
    changeDetection: ChangeDetectionStrategy.OnPush,
    selector: 'header',
    templateUrl: 'header.component.html',
    styleUrls: ['header.component.css']
})
export class HeaderComponent implements OnInit {    
    @ViewChild('logout')
    logoutComp: LogoutConfirmationComponent;
    
    @ViewChild('userNavigationMenu') userNavigationMenu: ElementRef;

    userName : string;

    constructor(
        private _router: Router,
        private _logger: Logger,
        private _sharedDataService: SharedDataService ,       
        private _utilityService: UtilityService,
        private _authService: AuthService,
        private _notificationService: NotificationService
    ) {
        this._logger.info("HeaderComponent : constructor ");
        this.userName = this._sharedDataService._sharedData.firstName;
    }

    ngOnInit() {
        this._logger.info("HeaderComponent : ngOnInit");
    }
    
    showLogoutConfirmation() {
        this._logger.info("HeaderComponent : showLogoutConfirmation ");
        this.logoutComp.showConfirmation();
    }
    
    onLogoutConfirmation(eventData: boolean) {
        this._logger.info("HeaderComponent : onLogoutConfirmation ");

        var logoutURL = ConfigurationSettings.appURL;

        this._authService.logOut(Constants.webApis.logout)
            .subscribe(
            (successResponse) => {
                this._logger.info("HeaderComponent : logOut : Success ");

                var url: string = Environment.appUrl + "?" + Constants.queryString.SessionExpired;

                if (successResponse.url.indexOf(Constants.queryString.SessionExpired) >= 0 || successResponse.url.indexOf(Constants.queryString.SessionKilled) >= 0)
                {   
                    this._utilityService.redirectToURL(url);
                    return;
                }

                if (successResponse.headers.get(Constants.requestHeader.contentType) != Constants.contentType.json) {
                    this._utilityService.redirectToURL(url);
                    return;
                }

                var response = successResponse.json();

                localStorage.clear();

                this._utilityService.redirectToURL(Environment.appUrl);
            },
            (errorResponse) => {                                
                this._logger.error("HeaderComponent : logOut : Error");                
                this._utilityService.redirectToURL(logoutURL);
            });        
    }

    openInNewWindow(url:string) {
        this._logger.info("HeaderComponent : openInNewWindow ");        
        this._utilityService.openInNewWindow(url);
    }
    
    toggleUserMenu(closeMenu?: boolean) {
        var classOpen = "open";

        if (!this.userNavigationMenu.nativeElement.classList.contains(classOpen) && (closeMenu === undefined || closeMenu === false)) {
            this.userNavigationMenu.nativeElement.classList.add(classOpen);            
        }
        else {
            this.userNavigationMenu.nativeElement.classList.remove(classOpen);
        }
    }
 
} 