[![](https://img.shields.io/nuget/v/soenneker.aws.basiccredentials.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.aws.basiccredentials/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.aws.basiccredentials/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.aws.basiccredentials/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.aws.basiccredentials.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.aws.basiccredentials/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.aws.basiccredentials/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.aws.basiccredentials/actions/workflows/codeql.yml)

# Soenneker.Aws.BasicCredentials

A .NET thread-safe singleton For AWS's basic credential object, BasicAWSCredentials.

## Install

```bash
dotnet add package Soenneker.Aws.BasicCredentials
```

## Quick start

```csharp
using Soenneker.Aws.BasicCredentials.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddBasicAwsCredentialsUtilAsSingleton();
```

Adds `IBasicAwsCredentialsUtil` as a singleton service.

## What you get

- `IBasicAwsCredentialsUtil` — A .NET thread-safe singleton For AWS's basic credential object, BasicAWSCredentials.
- `BasicAwsCredentialsUtilRegistrar` — A .NET thread-safe singleton For AWS's basic credential object, BasicAWSCredentials.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `BasicAwsCredentialsUtilRegistrar.AddBasicAwsCredentialsUtilAsSingleton(services)` | Adds `IBasicAwsCredentialsUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `BasicAwsCredentialsUtilRegistrar.AddBasicAwsCredentialsUtilAsScoped(services)` | Adds `IBasicAwsCredentialsUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
