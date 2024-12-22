using Soenneker.ServiceBus.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.ServiceBus.Client.Tests;

[Collection("Collection")]
public class ServiceBusClientUtilTests : FixturedUnitTest
{
    private readonly IServiceBusClientUtil _util;

    public ServiceBusClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IServiceBusClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
