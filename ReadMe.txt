
# Technologies used -

> Angular 5 with cli
> ASP.net MVC - Optional, in case you need any server side handling e.g Check if user is logged in inside home page view.
> Asp.net core WebAPI - Optional, is used to support 3 basic api that the demo Angular app needs. 
  This API can be a different project using any other API technology.

# Installation

> Install nodejs
> Install dotnet core sdk for windows - https://www.microsoft.com/net/core/ . Or any other Web or API framework
> npm install -g @angular/cli

# Restore packages

> Restore dotnet packages - go to project root from command prompt > type "dotnet restore" and press enter
> Restore node packages - go to project root from command prompt > type "npm install" and press enter

# Development

-For current project just - do "dotnet run" and you can now browse the app at "localhost:5000"

-Current project has both Angular and API in same project. If you are using diffrent API project, 
make sure its running and you can access the API being called from Angular app.

-Ensure that you have right urls updated in both files mentioned below 
- public-app/environment/environment.ts 
- app/environment/environment.ts 

# Deployment

> To create deployment package run following command 
$ "npm run build:prod"
$ "dotnet publish"

Package to be deployed -
- /dist 
- /dist1
- content of dotnet publish directory
- cut the assets folder from /dist and paste at root level
- since we have 2 copies of assets, delete the dist/assets folder
