import {
    NgModule,    
    ErrorHandler
} from '@angular/core';

import { Http } from '@angular/http';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import {
    Routes,
    RouterModule
} from '@angular/router';

// plugins

import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { SelectModule } from 'ng2-select';
import { NgbCarouselModule } from '@ng-bootstrap/ng-bootstrap';

import {
    TranslateModule,
    TranslateLoader,
    TranslateStaticLoader
} from 'ng2-translate';

import { MyDatePickerModule } from 'mydatepicker';

import { 
    RestrictInput,
    DisableControls
} from './directive/index';

import { ConfigurationSettings } from './infrastructure/index';

import {
    LogoutConfirmationComponent,
    HeaderComponent
} from './header/index';

import { FooterComponent } from './footer/footer.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { NavigationComponent } from './navigation/navigation.component';

import {
    DatexPipe,
    EllipsisPipe,
    SafeHtmlPipe,
    SplitPipe
} from './pipes/index';

declare var resourcesVersion: any;

export function translateLoaderFactory(http: Http) {
    return new TranslateStaticLoader(http, '/assets/resources', '.json?v=' + resourcesVersion);
}

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule,

        Ng2Bs3ModalModule,
        SelectModule,
        NgbCarouselModule,
        TranslateModule.forRoot({
            provide: TranslateLoader,
            useFactory: translateLoaderFactory,
            deps: [Http]
        }),
        MyDatePickerModule
    ],
    declarations: [
        // pipes
        DatexPipe,
        EllipsisPipe,
        SafeHtmlPipe,
        SplitPipe,

        // directives
        RestrictInput,
        DisableControls,

        // components
        NavigationComponent,
        SpinnerComponent,
        HeaderComponent,
        LogoutConfirmationComponent,
        FooterComponent
    ],
    providers: [
        
    ],
    exports: [
        // Angular modules
        BrowserModule,
        FormsModule,
        RouterModule,

        // plugins
        Ng2Bs3ModalModule,
        SelectModule,
        NgbCarouselModule,
        TranslateModule,
        MyDatePickerModule,

        // pipes
        DatexPipe,
        EllipsisPipe,
        SafeHtmlPipe,
        SplitPipe,

        // directives
        RestrictInput,
        DisableControls,

        // shared components
        NavigationComponent,
        SpinnerComponent,
        HeaderComponent,
        LogoutConfirmationComponent,
        FooterComponent
    ]
})

export class SharedModule { }