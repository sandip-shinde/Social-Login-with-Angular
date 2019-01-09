import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { PublicAppModule } from './public-app.module';
import { Environment } from './environments/environment';

if (Environment.environmentName == 'Production') {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(PublicAppModule)
  .catch(err => console.log(err));
