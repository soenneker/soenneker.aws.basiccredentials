using Amazon.Runtime;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Aws.BasicCredentials.Abstract;

/// <summary>
/// A .NET thread-safe singleton For AWS's basic credential object, BasicAWSCredentials
/// </summary>
public interface IBasicAwsCredentialsUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured basic AWS Credentials used by the basic aws credentials.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The requested basic AWS Credentials.</returns>
    BasicAWSCredentials GetSync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the configured basic AWS Credentials used by the basic aws credentials.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested basic AWS Credentials.</returns>
    ValueTask<BasicAWSCredentials> Get(CancellationToken cancellationToken = default);
}
