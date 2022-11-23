# Built in module loader

This modified sample is using the built-in module loader from Asp.net Core

It works by loading additional assemblies and looking for the [HostingStartupAttribute](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.hostingstartupattribute?view=aspnetcore-6.0) (see [Use hosting startup assemblies in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/platform-specific-configuration?view=aspnetcore-6.0))

The pattern is heavily based on the [talks](https://www.youtube.com/watch?v=LMuYH6b31AU) by Chris Klug

The key changes to the solution are:
- Added a new project (module) that configures the application (you may add as many of this as needed)
- Added an environment variable to tell the startup project to look for the `HostingStartup`s (see launchSettings.json and arch/ModuleReference1.png, this could be easily configured to be read from other sources, including files in asp.net core 3.1, still can be done in 6 and 7, but requires additional effort)
- The module assembly must be decorated with `HostingStartupAttribute` then it can configure the host builder (the attribute requires either a framework reference, a project with a framework reference to `Microsoft.AspNetCore.App` or use the project sdk or reference a project that uses the project sdk `Microsoft.NET.Sdk.Web`)

The results are as follows:
- The startup project does not technically need to reference the rest of the application (see arch/ServerReferences.png)
- The startup project does refernce the module for convinience (file copying, publish package, runtime store, etc, see arch/ModuleReference2.png)
- The module project is loaded and configured before leaving the `WebApplication.CreateBuilder(args);` call

# Original readme
Thanks to [Clear Measure](https://www.clearmeasure.com) for sponsoring this sample and episode of [Programming with Palermo](https://www.palermo.network).

[Code Sample](https://github.com/jeffreypalermo/onion-architecture-dotnet-6/)

[![.NET](https://github.com/jeffreypalermo/onion-architecture-dotnet-6/actions/workflows/dotnet.yml/badge.svg)](https://github.com/jeffreypalermo/onion-architecture-dotnet-6/actions/workflows/dotnet.yml)


# .NET 6 using Onion Architecture
This is a sample of .NET 6 implemented with Onion Architecture. This is how to get started with the core of the onion architecture. We start with a clean class library, unit tests, and a build. It's important to get this foundation correct before proceeding. We want our build working before adding any domain model or interfaces.  We then add an interface to a database with a "DataAccess" project. Then we add an interface to a user, with the Blazor UI project. We add UnitTests and IntegrationTests, wire it up to both GitHub Actions as well as Azure Pipelines to show how both work easily for continuous integration. We add a private build as well as CI build build scripts. Then we configure dependency management with an Inversion of Control container and refactor the project structure so that there is one project as an entry point while keeping all interfaces independent. The Blazor webassembly application has no access to the web services project (UI.Api). The Api project that contains the web services has no access to DataAccess. Additionally, the UI.Server project is stripped of all responsibility except to start the application and configure dependencies. 

![Onion Architecture solution structure](https://raw.githubusercontent.com/jeffreypalermo/onion-architecture-dotnet-6/master/arch/SolutionStructure.png)

![Application](https://user-images.githubusercontent.com/104212/175699896-6061441b-f969-4312-ba22-3f2edac0a1d9.png)

Thanks to [Clear Measure](https://www.clearmeasure.com) for sponsoring this sample and episode of [Programming with Palermo](https://www.palermo.network).
