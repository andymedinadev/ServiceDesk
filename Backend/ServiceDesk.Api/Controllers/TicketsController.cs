using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly GetTicketsHandler _getAll;
    private readonly GetTicketByIdHandler _getById;
    private readonly CreateTicketHandler _create;
    private readonly IValidator<CreateTicketCommand> _createValidator;
    private readonly CloseTicketHandler _close;
    private readonly IValidator<CloseTicketCommand> _closeValidator;
    private readonly UpdateTicketDetailsHandler _update;
    private readonly IValidator<UpdateTicketDetailsCommand> _updateValidator;
    private readonly AssignTicketHandler _assign;
    private readonly IValidator<AssignTicketCommand> _assignValidator;

    public TicketController(
        GetTicketByIdHandler getById,
        GetTicketsHandler getAll,
        CreateTicketHandler create,
        IValidator<CreateTicketCommand> createValidator,
        CloseTicketHandler close,
        IValidator<CloseTicketCommand> closeValidator,
        UpdateTicketDetailsHandler update,
        IValidator<UpdateTicketDetailsCommand> updateValidator,
        AssignTicketHandler assign,
        IValidator<AssignTicketCommand> assignValidator
    )
    {
        _getById = getById;
        _getAll = getAll;
        _create = create;
        _createValidator = createValidator;
        _close = close;
        _closeValidator = closeValidator;
        _update = update;
        _updateValidator = updateValidator;
        _assign = assign;
        _assignValidator = assignValidator;
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
        [FromBody] CreateTicketRequest? request,
        CancellationToken ct = default
    )
    {
        if (request is null)
        {
            return BadRequest();
        }

        var command = new CreateTicketCommand(
            request.Title,
            request.Description,
            request.CategoryId,
            request.CreatedById,
            request.Priority
        );

        var validation = await _createValidator.ValidateAsync(command, ct);

        if (!validation.IsValid)
        {
            return CreateValidationProblem(validation);
        }

        var id = await _create.Handle(command, ct);

        var ticket = await _getById.Handle(new GetTicketByIdQuery(id), ct);

        return CreatedAtAction(nameof(GetById), new { id }, ticket);
    }

    [HttpPost("{id:int}/close")]
    public async Task<IActionResult> Close(
        int id,
        [FromBody] CloseTicketRequest? request,
        CancellationToken ct = default
    )
    {
        if (request is null)
        {
            return BadRequest();
        }

        var command = new CloseTicketCommand(id, request.ClosedById);

        var validation = await _closeValidator.ValidateAsync(command, ct);

        if (!validation.IsValid)
        {
            return CreateValidationProblem(validation);
        }

        await _close.Handle(command, ct);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateTicketDetailsRequest? request,
        CancellationToken ct = default
    )
    {
        if (request is null)
        {
            return BadRequest();
        }

        var command = new UpdateTicketDetailsCommand(
            id,
            request.Title,
            request.Description,
            request.CategoryId,
            request.UpdatedById
        );

        var validation = await _updateValidator.ValidateAsync(command, ct);

        if (!validation.IsValid)
        {
            return CreateValidationProblem(validation);
        }

        await _update.Handle(command, ct);

        return NoContent();
    }

    [HttpPost("{id:int}/assign")]
    public async Task<IActionResult> Assign(
        int id,
        [FromBody] AssignTicketRequest? request,
        CancellationToken ct = default
    )
    {
        if (request is null)
        {
            return BadRequest();
        }

        var command = new AssignTicketCommand(id, request.AssignedToId, request.ChangedById);

        var validation = await _assignValidator.ValidateAsync(command, ct);

        if (!validation.IsValid)
        {
            return CreateValidationProblem(validation);
        }

        await _assign.Handle(command, ct);

        return NoContent();
    }

    private ActionResult CreateValidationProblem(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }

        return ValidationProblem(ModelState);
    }
}
