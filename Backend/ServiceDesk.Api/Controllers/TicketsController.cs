using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly GetTicketsHandler _getAll;
    private readonly GetTicketByIdHandler _getById;
    private readonly CreateTicketHandler _create;

    public TicketController(
        GetTicketByIdHandler getById,
        GetTicketsHandler getAll,
        CreateTicketHandler create
    )
    {
        _getById = getById;
        _getAll = getAll;
        _create = create;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] bool includeClosed = true,
        CancellationToken ct = default
    )
    {
        var tickets = await _getAll.Handle(new GetTicketsQuery(includeClosed), ct);

        return Ok(tickets);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct = default)
    {
        var ticket = await _getById.Handle(new GetTicketByIdQuery(id), ct);

        if (ticket is null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateTicketCommand command,
        CancellationToken ct
    )
    {
        var id = await _create.Handle(command, ct);
        return CreatedAtAction(nameof(GetById), new { id });
    }
}
