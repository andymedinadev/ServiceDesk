using ServiceDesk.Domain.Entities;

public class CreateTicketHandler
{
    private readonly ITicketRepository _tickets;
    private readonly IUserRepository _users;
    private readonly IUnitOfWork _uow;

    public CreateTicketHandler(ITicketRepository tickets, IUserRepository users, IUnitOfWork uow) =>
        (_tickets, _users, _uow) = (tickets, users, uow);

    public async Task<int> Handle(CreateTicketCommand command, CancellationToken ct = default)
    {
        var creator =
            await _users.GetByIdAsync(command.CreatedById, ct)
            ?? throw new InvalidOperationException("Creator not found.");

        var ticket = new Ticket
        {
            Title = command.Title.Trim(),
            Description = command.Description.Trim(),
            CategoryId = command.CategoryId,
            CreatedById = creator.Id,
            Priority = command.Priority,
            Status = TicketStatus.Open,
            CreatedAt = DateTime.Now,
        };

        ticket.StatusHistory.Add(
            new TicketStatusHistory
            {
                FromStatus = TicketStatus.Created,
                ToStatus = TicketStatus.Open,
                ChangedAt = DateTime.Now,
                ChangedById = command.CreatedById,
            }
        );

        await _tickets.AddAsync(ticket, ct);

        await _uow.SaveChangesAsync(ct);

        return ticket.Id;
    }
}
