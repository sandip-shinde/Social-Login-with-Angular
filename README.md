We are using reactjs to build web client and its going to be hosted under .net core 2.0 mvc website.

# Installation

> Install nodejs
> Install visual studio code - https://code.visualstudio.com/
> Install vscode c# extension ( use extension tab )- C# for Visual Studio Code (powered by OmniSharp)
> Install dotnet core sdk for windows - https://www.microsoft.com/net/core/

# Load project

> Get sourcecode - Checkout client.project.web folder to local path
> Open project - open vscode and open local project folder "client.project.web"
> Restore dotnet packages - from vscode terminal - type "dotnet restore" and press enter
> Restore node packages - from vscode terminal - type "npm install" and press enter

# Development

Run and project and continue your dev work. React will keep the app refreshing in browser.
> Run dummy api - open command prompt - go to root of project client.project.web - do "dotnet run" 
> Put project in run mode - from vscode terminal do "npm start"
> Stop the running project - from vscode terminal do "ctl c" and then type "y"

# Deployment

> Create reactjs package - from vscode terminal - do "npm run build". Package is created under build folder.
> Deploy the react package under iis. Assign required domain or port
> Create API package - from vscode terminal do "dotnet publish". Package is created under /bin/{env}/netcoreapp2.0/publish
> Deploy api package under iis. Change app pool setting as no managed code. Assign required domain or port.