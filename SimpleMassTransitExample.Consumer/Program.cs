using System.Runtime.InteropServices;
using SimpleMassTransitExample.Consumer;
using Topshelf;
using Topshelf.Runtime.DotNetCore;

HostFactory.Run(h =>
{
    if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
    {
        h.UseEnvironmentBuilder(target => new DotNetCoreEnvironmentBuilder(target));
    }
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
