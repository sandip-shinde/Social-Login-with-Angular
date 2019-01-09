import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { PublicAppModule } from './public-app.module';

const platform = platformBrowserDynamic();
platform.bootstrapModule(PublicAppModule);
