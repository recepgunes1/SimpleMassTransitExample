using System.Text.Json;
using MassTransit;
using SimpleMassTransitExample.SharedLibrary.Models;

namespace SimpleMassTransitExample.Consumer;

public class UserCreatedConsumer : IConsumer<UserCreated>
{
    public async Task Consume(ConsumeContext<UserCreated> context)
    {
        await Task.Run(() => { Thread.Sleep(1); });
        var message = JsonSerializer.Serialize(context.Message);
        Console.WriteLine(message);
    }
}