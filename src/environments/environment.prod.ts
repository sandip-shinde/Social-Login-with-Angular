// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: true,
  environmentName: 'Production',
  domain : '.client1.com',
  appUrl: 'http://localhost:4200/',
  apiUrl: 'http://localhost:5000/api/',
  errorPageUrl: 'http://localhost:4200/',
  apiTokenUrl: 'http://localhost:5000/token',
  GoogleloginApi: '775043747121-3i7bejbtq0bo235ck37s1652f3rl6crn.apps.googleusercontent.com'

};

