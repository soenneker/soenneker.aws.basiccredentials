[![](https://img.shields.io/nuget/v/soenneker.aws.basiccredentials.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.aws.basiccredentials/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.aws.basiccredentials/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.aws.basiccredentials/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.aws.basiccredentials.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.aws.basiccredentials/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.aws.basiccredentials/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.aws.basiccredentials/actions/workflows/codeql.yml)

# Soenneker.Aws.BasicCredentials

Creates and caches the AWS SDK's `BasicAWSCredentials` from application configuration.

## Installation

```bash
dotnet add package Soenneker.Aws.BasicCredentials
```

## Configuration

The utility requires these keys:

```json
{
  "Aws": {
    "AccessKey": "access-key-id",
    "SecretKey": "secret-access-key"
  }
}
```

Use a secret provider or environment variables (`Aws__AccessKey` and `Aws__SecretKey`) in deployed applications. Do not commit credentials to configuration files.

## Registration and use

```csharp
using Amazon.Runtime;
using Soenneker.Aws.BasicCredentials.Abstract;
using Soenneker.Aws.BasicCredentials.Registrars;

builder.Services.AddBasicAwsCredentialsUtilAsSingleton();

public sealed class AwsClientFactory(IBasicAwsCredentialsUtil credentialsUtil)
{
    public async ValueTask<BasicAWSCredentials> GetCredentials(
        CancellationToken cancellationToken) =>
        await credentialsUtil.Get(cancellationToken);
}
```

`GetSync()` is available for callers that cannot use the asynchronous API.

## Lifecycle and security

- Credentials are created on first access and reused for the utility's lifetime.
- Configuration changes and rotated keys are not picked up after initialization; replace or dispose the utility to create a new credential object.
- Missing configuration fails credential creation rather than returning blank credentials.
- `BasicAWSCredentials` represents long-lived access keys. Prefer an AWS role or temporary credential provider when the hosting environment supports one.
- Let the DI container dispose registered instances. Do not log the credential object or its secret values.
