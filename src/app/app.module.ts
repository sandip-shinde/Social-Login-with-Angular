import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { ServiceWorkerModule } from '@angular/service-worker';

import { CoreModule } from '@core/core.module';
import { GlobalModule } from '@global/global.module';
import { SharedModule } from '@shared/shared.module';

import { routing } from './app.routing';
import { ShopModule } from './shop-module/shop.module';
import { OrderModule } from './order-module/order.module';

import { LoginComponent } from './login/index';
import { AppComponent } from './app.component';

import { environment } from '../environments/environment';

import {GoogleLoginProvider, SocialLoginModule, AuthServiceConfig } from "angularx-social-login";

export function getAuthServiceConfigs() {
  const config = new AuthServiceConfig(
      [          
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider(environment.GoogleloginApi)       
        }
      ]
  );
  return config;
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    CoreModule.forRoot(
      { environmentName: environment.environmentName
        , apiTokenUrl: ''
        , appUrl: environment.appUrl
        , domain: environment.domain
      }),
    GlobalModule.forRoot(),
    SharedModule,
    routing,
    ShopModule,
    OrderModule,
    SocialLoginModule
  ],
  providers: [{
    provide: AuthServiceConfig,
    useFactory: getAuthServiceConfigs
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
