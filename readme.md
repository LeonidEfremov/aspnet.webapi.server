# AspNet.WebApi.Server
[![NuGet Version](https://img.shields.io/nuget/v/AspNet.WebApi.Server.svg?style=flat)](https://www.nuget.org/packages?q=AspNet.WebApi.Server)
[![Build Status](https://img.shields.io/appveyor/tests/LeonidEfremov/aspnet-webapi-server.svg?style=flat)](https://ci.appveyor.com/project/LeonidEfremov/aspnet-webapi-server/)
[![SonarQube Coverage](https://img.shields.io/sonar/http/sonarcloud.io/AspNet.WebApi.Server/coverage.svg?style=flat)](https://sonarcloud.io/dashboard?id=AspNet.WebApi.Server)
[![Libraries.io dependency status](https://img.shields.io/librariesio/github/LeonidEfremov/aspnet.webapi.server.svg)](https://libraries.io/github/LeonidEfremov/aspnet.webapi.server)
[![License](https://img.shields.io/github/license/LeonidEfremov/AspNet.WebApi.Server.svg?style=flat)](https://github.com/LeonidEfremov/aspnet.webapi.server/blob/master/license.md)

**Base library for .NET Core API services.**

## About

Base library for .NET Core self-hosted API services. Provide all neccesary services for Web API like swagger documentation, healthcheck and metrics endpoints.

## Requirements

1. .NET 6.0 runtime and above
2. MSVS 2022

## Usage

Create new Host class:

``` csharp
public class Host : Server.Host { }
```

Define overrides int Startup class:

``` csharp
public class Startup : Server.Startup { }
```


## Predefined API url

1. `/` show default Web API page
2. `/swagger` show SwaggerUI API Reference Documentation
7. `/env` exposes environment information about the application e.g. OS, Machine Name, Assembly Name, Assembly Version etc.

## Deployment

### Windows
Install script
```bash
sc create "AspNet.WebApi.Server.Example" binpath= "dotnet %CD%\AspNet.WebApi.Server.Example.dll --run-as-service true" start= auto 
sc start "AspNet.WebApi.Server.Example"
```
uninstall script
```bash
sc stop "AspNet.WebApi.Server.Example"
sc delete "AspNet.WebApi.Server.Example"
```

## Reference

1. [WebApi](https://www.asp.net/web-api)
2. [Swagger](http://swagger.io/)
3. [NSwag](https://github.com/RSuter/NSwag/)
3. [App.Metrics](https://www.app-metrics.io/)

## Authors

* [Leonid Efremov](mailto:leonid.efremov@rypterium.com)