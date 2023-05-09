using System.Text.Json;
using MassTransit;
using SimpleMassTransitExample.SharedLibrary.Models;

namespace SimpleMassTransitExample.Consumer;

public class UserCreatedConsumer : IConsumer<UserCreated>
{
    public async Task Consume(ConsumeContext<UserCreated> context)
    {
        var message = JsonSerializer.Serialize(context.Message);
        await Console.Out.WriteLineAsync(message);
    }
}