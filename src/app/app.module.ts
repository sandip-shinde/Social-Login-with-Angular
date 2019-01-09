import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { ServiceWorkerModule } from '@angular/service-worker';

import { CoreModule } from '../core-module/core.module';
import { GlobalModule } from './global-module/global.module';
import { SharedModule } from './shared-module/shared.module';

import { routing } from './app.routing';
import { ShopModule } from './shop-module/shop.module';
import { OrderModule } from './order-module/order.module';

import { LoginComponent } from './login/index';
import { AppComponent } from './app.component';

import { environment } from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    CoreModule.forRoot({ environmentName: environment.environmentName, apiTokenUrl: '', appUrl: environment.appUrl }),
    GlobalModule.forRoot(),
    SharedModule,
    routing,
    ShopModule,
    OrderModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
