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
    BasicAWSCredentials GetSync(CancellationToken cancellationToken = default);

    ValueTask<BasicAWSCredentials> Get(CancellationToken cancellationToken = default);
}
