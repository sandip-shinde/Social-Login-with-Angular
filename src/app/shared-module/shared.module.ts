import {
    NgModule,
    ErrorHandler
} from '@angular/core';

import { Http } from '@angular/http';
import {HttpClientModule, HttpClient} from '@angular/common/http';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import {
    Routes,
    RouterModule
} from '@angular/router';

// plugins

import { BsModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { SelectModule } from 'ng2-select';
import { NgbCarouselModule } from '@ng-bootstrap/ng-bootstrap';

import {TranslateModule, TranslateLoader} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';

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

export function createTranslateLoader(http: HttpClient) {
    return new TranslateHttpLoader(http, './assets/i18n/', '.json?v=' + resourcesVersion);
}

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule,

        BsModalModule,
        SelectModule,
        NgbCarouselModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: (createTranslateLoader),
                deps: [HttpClient]
            }
        })
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
        BsModalModule,
        SelectModule,
        NgbCarouselModule,
        TranslateModule,

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
