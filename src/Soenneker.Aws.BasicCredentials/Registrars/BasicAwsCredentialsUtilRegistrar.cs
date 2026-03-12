using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Aws.BasicCredentials.Abstract;

namespace Soenneker.Aws.BasicCredentials.Registrars;

/// <summary>
/// A .NET thread-safe singleton For AWS's basic credential object, BasicAWSCredentials
/// </summary>
public static class BasicAwsCredentialsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IBasicAwsCredentialsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddBasicAwsCredentialsUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IBasicAwsCredentialsUtil, BasicAwsCredentialsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IBasicAwsCredentialsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddBasicAwsCredentialsUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IBasicAwsCredentialsUtil, BasicAwsCredentialsUtil>();

        return services;
    }
}