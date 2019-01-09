import { NgModule } from '@angular/core';

import { SharedModule } from '../shared-module/shared.module';
import { InvoiceComponent } from "app/order-module/invoice/invoice.component";
import { OrderComponent } from "app/order-module/order/order.component";

@NgModule({
    imports: [
        SharedModule
    ],
    declarations: [
        InvoiceComponent,
        OrderComponent
    ],
    providers: [
        
    ]
})
export class OrderModule { }