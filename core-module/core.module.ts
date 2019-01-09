import {
    NgModule,
    APP_INITIALIZER,
    ErrorHandler,
    ModuleWithProviders,
    SkipSelf,
    Optional
} from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {
    HttpModule,
    Http,
    BrowserXhr,
    RequestOptions,
    XHRBackend
} from '@angular/http';

import {
    Logger,
    Options as LoggerOptions,
    Level as LoggerLevel
} from 'angular2-logger/core';

import {
    ToastModule,
    ToastOptions
} from 'ng2-toastr/ng2-toastr';

import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';

import {
    LoggingErrorHandlerOptions,
    GlobalErrorHandlerComponent,
    GlobalErrorLoggingService,
    GlobalErrorDialogComponent
} from './errorHandling/index';

import {
    CustomBrowserXhr,
    HttpService,
    AuthService
} from './extensions/index';

import {
    Constants,
    ConfigurationSettings,
    ToastrOptions,
    EnvironmentConfig,
    UtilityService,
    ValidationService
} from './infrastructure/index';

import { HttpResponse } from './extensions/http-response.model';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

import { SpinnerService } from './spinner/spinner.service';


import {
    ToastrComponent,
    ToastrMessageHelperService,
    ToastrService
} from './toastr/index';

export function httpServiceFactory(backend: XHRBackend, options: RequestOptions, utilityService: UtilityService, authService: AuthService) {
    return new HttpService(backend, options, utilityService, authService);
}

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        BrowserAnimationsModule,
        HttpModule,
        Ng2Bs3ModalModule,
        ToastModule.forRoot(ToastrOptions)
    ],
    declarations: [
        GlobalErrorDialogComponent,
        ToastrComponent,
        PageNotFoundComponent
    ],
    exports: [
        GlobalErrorDialogComponent,
        ToastrComponent,
        PageNotFoundComponent
    ],
    providers: [
        {
            provide: LoggerOptions,
            useValue: { level: LoggerLevel.INFO }
        },
        Logger,
        UtilityService,
        ToastrMessageHelperService,
        ToastrService,
        ValidationService,
        AuthService,
        SpinnerService,
        GlobalErrorLoggingService,
        {
            provide: LoggingErrorHandlerOptions,
            useValue: {
                isRethrowError: ConfigurationSettings.isRethrowErrorInsideGlobalErrorHandler,
                isUnwrapError: ConfigurationSettings.isUnwrapErrorInsideGlobalErrorHandler,
                isLogErrorToConsole: ConfigurationSettings.islogErrorToConsoleInsideGlobalErrorHandler,
                isSendErrorToServer: ConfigurationSettings.isSendErrorToServerInsideGlobalErrorHandler,
                isShowErrorDialog: ConfigurationSettings.isShowErrorDialogInsideGlobalErrorHandler
            }
        },
        {
            provide: ErrorHandler,
            useClass: GlobalErrorHandlerComponent
        },
        {
            provide: BrowserXhr,
            useClass: CustomBrowserXhr
        },
        {
            provide: HttpService,
            useFactory: httpServiceFactory,
            deps: [XHRBackend, RequestOptions, UtilityService, AuthService]
        }
    ]
})

export class CoreModule {

    //Prevent core module to be injected multiple times
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        if (parentModule) {
            throw new Error(
                'CoreModule is already loaded. Import it in the AppModule only');
        }
    }

    static forRoot(config: EnvironmentConfig): ModuleWithProviders {
        return {
            ngModule: CoreModule,
            providers: [
                { provide: EnvironmentConfig, useValue: config }
            ]
        };
    }

}