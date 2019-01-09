import { platformBrowser } from '@angular/platform-browser';
import { enableProdMode } from '@angular/core';
import { PublicAppModuleNgFactory } from '../aot/public-app/public-app.module.ngfactory';

enableProdMode();
platformBrowser().bootstrapModuleFactory(PublicAppModuleNgFactory);