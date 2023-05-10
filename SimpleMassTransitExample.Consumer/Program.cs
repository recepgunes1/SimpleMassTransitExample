using SimpleMassTransitExample.Consumer;
using Topshelf;


HostFactory.Run(h =>
{
    h.Service<MassTransitService>(s =>
    {
        s.ConstructUsing(_ => new MassTransitService());
        s.WhenStarted(tc => tc.Start(null));
        s.WhenStopped(tc => tc.Stop(null));
    });
    h.RunAsLocalSystem();
    h.SetDescription("MassTransit Service Example");
    h.SetDisplayName("MassTransit Service");
    h.SetServiceName("MassTransitService");
});