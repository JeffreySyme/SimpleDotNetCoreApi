# Simple .NET Core Api
Simple .NET Core Api application with Mediator and Swagger
## Purpose
.NET Core Template for spinning up a Web Api application quickly.
This project is generic, minimal and uses popular .NET libraries.
## Installation
Clone the repo and run the following command
```
dotnet new -i [absolute-path-to-root]
```
Alternatively you can navigate to the root folder and run
```
dotnet new -i .\
```
To create a project with the template run
```
dotnet new simpledotnetcoreapi -n [name-of-project]
```
Please see this [blog](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates) post for more information on custom .NET Core Templates
## Removing
If you would like to remove the template run
```
dotnet new -u [absolute-path-to-root]
```
The path here must be absolute. There is no support for relative paths when removing a template.
## Technologies
- [MediatR](https://github.com/jbogard/MediatR)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- [.NET Core 3.1](https://dotnet.microsoft.com/download)
- [Swagger](https://swagger.io/)
