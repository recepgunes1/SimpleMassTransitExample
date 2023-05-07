using MassTransit;
using SimpleMassTransitExample.Consumer;

var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("user-created-event", e => { e.Consumer<UserCreatedConsumer>(); });
});

await bus.StartAsync();
try
{
    Console.WriteLine("Press [Enter] to exit");
    await Task.Run(Console.ReadLine);
}
finally
{
    await bus.StopAsync();
}