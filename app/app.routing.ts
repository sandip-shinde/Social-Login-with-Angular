import { ModuleWithProviders } from '@angular/core';

import {
    Routes,
    RouterModule
} from '@angular/router';

import { PageNotFoundComponent } from '../core-module/index';

import { AuthGuardService } from './global-module/index';

import { Constants } from './shared-module/index';

import { ProductComponent } from "app/shop-module/product/product.component";
import { OfferComponent } from "app/shop-module/offer/offer.component";
import { InvoiceComponent } from "app/order-module/invoice/invoice.component";
import { OrderComponent } from "app/order-module/order/order.component";

const appRoutes: Routes = [
    {
        path: Constants.uiRoutes.login,
        redirectTo: Constants.uiRoutes.product,
        pathMatch: 'full'
    },
    {
        path: Constants.uiRoutes.empty,
        redirectTo: Constants.uiRoutes.product,
        pathMatch: 'full'
    },
    {
        path: Constants.uiRoutes.product,
        component: ProductComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: Constants.uiRoutes.offer,
        component: OfferComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: Constants.uiRoutes.order,
        component: OrderComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: Constants.uiRoutes.invoice,
        component: InvoiceComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: '**',
        component: PageNotFoundComponent,
        canActivate: [AuthGuardService]
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);