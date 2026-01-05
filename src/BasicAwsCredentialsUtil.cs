using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using Soenneker.Aws.BasicCredentials.Abstract;
using Soenneker.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Aws.BasicCredentials;

/// <inheritdoc cref="IBasicAwsCredentialsUtil"/>
public sealed class BasicAwsCredentialsUtil : IBasicAwsCredentialsUtil
{
    private readonly AsyncSingleton<BasicAWSCredentials> _client;
    private readonly IConfiguration _configuration;

    public BasicAwsCredentialsUtil(IConfiguration configuration)
    {
        _configuration = configuration;
        _client = new AsyncSingleton<BasicAWSCredentials>(CreateCredentials);
    }

    private BasicAWSCredentials CreateCredentials()
    {
        var accessKey = _configuration.GetValueStrict<string>("Aws:AccessKey");
        var secretKey = _configuration.GetValueStrict<string>("Aws:SecretKey");

        return new BasicAWSCredentials(accessKey, secretKey);
    }

    public BasicAWSCredentials GetSync(CancellationToken cancellationToken = default)
    {
        return _client.GetSync(cancellationToken);
    }

    public ValueTask<BasicAWSCredentials> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}