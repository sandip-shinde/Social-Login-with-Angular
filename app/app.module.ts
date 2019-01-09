import { NgModule } from '@angular/core';

import { CoreModule }   from '../core-module/core.module';
import { GlobalModule } from './global-module/global.module';
import { SharedModule } from './shared-module/shared.module';

import { routing } from './app.routing';
import { ShopModule } from './shop-module/shop.module';
import { OrderModule } from './order-module/order.module';

// app imports
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HomeService } from './home/home.service';
import { Environment } from './environment';

@NgModule({
    imports: [
        CoreModule.forRoot({ environmentName: Environment.environmentName, apiTokenUrl: '', appUrl: Environment.appUrl }),
        GlobalModule.forRoot(),
        SharedModule,
        routing,

        ShopModule,
        OrderModule

    ],
    declarations: [
        AppComponent,
        HomeComponent
   ],
    bootstrap: [
        AppComponent
    ],
    providers: [        
        HomeService
    ]
})
export class AppModule { }

