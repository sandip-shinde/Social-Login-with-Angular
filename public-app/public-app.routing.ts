import { ModuleWithProviders } from '@angular/core';

import {
    Routes,
    RouterModule
} from '@angular/router';

import { PublicComponent } from './public/index';
import { LoginComponent } from './login/index';

import { PageNotFoundComponent } from '../core-module/page-not-found/page-not-found.component';

import {
    Constants,
    AuthGuardService
} from './shared/index';

const appRoutes: Routes = [
    {
        path: Constants.uiRoutes.login,
        component: LoginComponent,
        canActivate: [AuthGuardService]
    },     
    {
        path: Constants.uiRoutes.empty,
        component: LoginComponent,
        canActivate: [AuthGuardService]

    },   
    {
        path: '**',
        component: PageNotFoundComponent,
        canActivate: [AuthGuardService]
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);