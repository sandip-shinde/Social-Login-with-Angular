// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: true,
  environmentName: 'Production',
  appUrl: 'http://localhost:9400/',
  apiUrl: 'http://localhost:9401/api/',
  errorPageUrl: 'http://localhost:9400/',
  apiTokenUrl: 'http://localhost:9401/token'
};
