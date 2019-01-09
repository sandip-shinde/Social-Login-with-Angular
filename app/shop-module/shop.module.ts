import {
    NgModule,
    Optional,
    SkipSelf,
    ModuleWithProviders
} from '@angular/core';

import { ProductComponent } from "app/shop-module/product/product.component";
import { OfferComponent } from "app/shop-module/offer/offer.component";
import { SharedModule } from "app/shared-module/shared.module";

@NgModule({
    imports: [
        SharedModule
    ],
    declarations: [
        ProductComponent,   
        OfferComponent
    ],
    providers: [
    ]
})

export class ShopModule {}