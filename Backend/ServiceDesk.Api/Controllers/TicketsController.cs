using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly CreateTicketHandler _create;

    public TicketController(CreateTicketHandler create) => _create = create;

    [HttpGet("{id:int}")]
    public IActionResult Get(int id) => Ok(new { id });

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateTicketCommand command,
        CancellationToken ct
    )
    {
        var id = await _create.Handle(command, ct);
        return CreatedAtAction(nameof(Get), new { id }, new { id });
    }
}
