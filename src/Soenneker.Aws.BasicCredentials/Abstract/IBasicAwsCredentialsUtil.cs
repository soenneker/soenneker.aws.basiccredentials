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
    /// Gets sync.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the operation.</returns>
    BasicAWSCredentials GetSync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<BasicAWSCredentials> Get(CancellationToken cancellationToken = default);
}
