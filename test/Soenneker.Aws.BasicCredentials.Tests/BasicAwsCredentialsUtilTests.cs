using Soenneker.Aws.BasicCredentials.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Aws.BasicCredentials.Tests;

[Collection("Collection")]
public sealed class BasicAwsCredentialsUtilTests : FixturedUnitTest
{
    private readonly IBasicAwsCredentialsUtil _util;

    public BasicAwsCredentialsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IBasicAwsCredentialsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
