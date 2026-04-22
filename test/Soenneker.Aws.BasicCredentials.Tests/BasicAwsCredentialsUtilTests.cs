using Soenneker.Aws.BasicCredentials.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Aws.BasicCredentials.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class BasicAwsCredentialsUtilTests : HostedUnitTest
{
    private readonly IBasicAwsCredentialsUtil _util;

    public BasicAwsCredentialsUtilTests(Host host) : base(host)
    {
        _util = Resolve<IBasicAwsCredentialsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
