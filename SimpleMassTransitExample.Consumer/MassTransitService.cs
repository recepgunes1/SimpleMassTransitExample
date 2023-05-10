using MassTransit;
using Topshelf;

namespace SimpleMassTransitExample.Consumer;

public class MassTransitService : ServiceControl
{
    private readonly IBusControl _busControl;

    public MassTransitService()
    {
        _busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host("s_rabbitmq", 5672, "/", s =>
            {
                s.Username("guest");
                s.Password("guest");
            });
            cfg.ReceiveEndpoint("user-created-event", e => { e.Consumer<UserCreatedConsumer>(); });
        });
    }
    
    public bool Start(HostControl? hostControl)
    {
        _busControl.StartAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool Stop(HostControl? hostControl)
    {
        _busControl.StopAsync().GetAwaiter().GetResult();
        return true;
    }
}