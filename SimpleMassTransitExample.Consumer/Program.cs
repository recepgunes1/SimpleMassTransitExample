using MassTransit;
using SimpleMassTransitExample.Consumer;

var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host("s_rabbitmq", 5672, "/",
        s =>
        {
            s.Username("guest");
            s.Password("guest");
        });

    // cfg.Host(new Uri("s_rabbitmq:5672"), h =>
    // {
    //     h.Username("guest");
    //     h.Password("guest");
    // });
    cfg.ReceiveEndpoint("user-created-event", e => { e.Consumer<UserCreatedConsumer>(); });
});

await bus.StartAsync();
try
{
    Console.WriteLine("Press [Enter] to exit");
    await Console.In.ReadLineAsync();
}
finally
{
    await bus.StopAsync();
}