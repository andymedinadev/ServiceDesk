public class AssignTicketHandler
{
    private readonly ITicketRepository _tickets;
    private readonly IUserRepository _users;
    private readonly IUnitOfWork _uow;

    public AssignTicketHandler(ITicketRepository tickets, IUserRepository users, IUnitOfWork uow) =>
        (_tickets, _users, _uow) = (tickets, users, uow);

    public async Task Handle(AssignTicketCommand command, CancellationToken ct = default)
    {
        var ticket =
            await _tickets.GetByIdAsync(command.TicketId, ct)
            ?? throw new KeyNotFoundException("Ticket not found.");

        if (command.AssignedToId.HasValue)
        {
            var assignee =
                await _users.GetByIdAsync(command.AssignedToId.Value, ct)
                ?? throw new InvalidOperationException("Assignee not found.");

            ticket.AssignedToId = assignee.Id;
        }
        else
        {
            ticket.AssignedToId = null;
        }

        ticket.UpdatedAt = DateTime.Now;

        await _tickets.UpdateAsync(ticket, ct);

        await _uow.SaveChangesAsync(ct);
    }
}
