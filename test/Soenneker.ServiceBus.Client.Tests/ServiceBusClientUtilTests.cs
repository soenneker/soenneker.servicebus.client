using Soenneker.ServiceBus.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.ServiceBus.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ServiceBusClientUtilTests : HostedUnitTest
{
    private readonly IServiceBusClientUtil _util;

    public ServiceBusClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<IServiceBusClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
