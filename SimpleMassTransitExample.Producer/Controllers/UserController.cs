using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SimpleMassTransitExample.Producer.DTOs;
using SimpleMassTransitExample.SharedLibrary.Models;

namespace SimpleMassTransitExample.Producer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IPublishEndpoint _publishEndpoint;

    public UserController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDto dto)
    {
        await _publishEndpoint.Publish(new UserCreated
        {
            Name = dto.Name,
            Age = dto.Age
        });
        return Ok();
    }
}