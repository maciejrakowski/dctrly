using Microsoft.AspNetCore.Mvc;

namespace dctrly.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{

    private readonly ILogger<EventsController> _logger;

    public EventsController(ILogger<EventsController> logger)
    {
        _logger = logger;
    }
}