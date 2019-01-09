import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { Http } from '@angular/http';

import {
    TranslateModule,
    TranslateLoader,
    TranslateStaticLoader
} from 'ng2-translate';

import { CoreModule } from '../core-module/core.module';
import { routing } from './public-app.routing';

import { PublicAppComponent } from './public-app.component';

import { Environment } from './environment';

import {
    ConfigurationSettings,
    Constants
} from './shared/index';

import {
    NotificationService,
    AuthGuardService
} from './shared/index';

import { PublicComponent } from './public/index';
import { LoginComponent } from './login/index';

declare var resourcesVersion: any;

export function translateLoaderFactory(http: Http) {
    return new TranslateStaticLoader(http, '/assets/resources', '.json?v=' + resourcesVersion);
}

@NgModule({
    imports: [
        BrowserModule,        
        FormsModule,
        TranslateModule.forRoot({
            provide: TranslateLoader,
            useFactory: translateLoaderFactory,
            deps: [Http]
        }),

        CoreModule.forRoot({ environmentName: Environment.environmentName, apiTokenUrl: '', appUrl: Environment.appUrl }),        
        routing
    ],
    declarations: [
        PublicAppComponent,
        PublicComponent,
        LoginComponent
   ],
    bootstrap: [
        PublicAppComponent
    ],
    providers: [
        NotificationService,
        AuthGuardService
    ]
})
export class PublicAppModule { }