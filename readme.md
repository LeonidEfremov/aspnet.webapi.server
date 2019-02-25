# AspNet.WebApi.Server
[![NuGet Version](https://img.shields.io/nuget/v/AspNet.WebApi.Server.svg?style=flat)](https://www.nuget.org/packages?q=AspNet.WebApi.Server)
[![Build Status](https://img.shields.io/appveyor/tests/LeonidEfremov/aspnet-webapi-server.svg?style=flat)](https://ci.appveyor.com/project/LeonidEfremov/aspnet-webapi-server/)
[![SonarQube Coverage](https://img.shields.io/sonar/http/sonarcloud.io/AspNet.WebApi.Server/coverage.svg?style=flat)](https://sonarcloud.io/dashboard?id=AspNet.WebApi.Server)
[![License](https://img.shields.io/github/license/LeonidEfremov/AspNet.WebApi.Server.svg?style=flat)](https://github.com/LeonidEfremov/aspnet.webapi.server/blob/master/license.md)


**Base library for .NET Core API services.**

## About

Base library for .NET Core self-hosted API services. Provide all neccesary services for Web API like swagger documentation, healthcheck and metrics endpoints.

## Requirements

1. .NET Core 2.2 runtime and above
2. MSVS 2017

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
3. `/redoc` show ReDoc API Reference Documentation
3. `/health` executes the configured health checks and response with the result of each health check as well as an overall health status
4. `/ping` used to determine if you can get a successful pong response with a 200 HTTP status code, useful for load balancers
5. `/metrics` exposes a metrics snapshot using the configured metrics formatter
6. `/metrics-text` exposes a metrics snapshot using the configured text formatter
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