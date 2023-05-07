namespace SimpleMassTransitExample.SharedLibrary.Models;

public sealed class UserCreated
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public int Age { get; set; } = default!;
}