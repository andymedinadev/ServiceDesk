public class SetTicketPriorityHandler
{
    private readonly ITicketRepository _tickets;
    private readonly IUnitOfWork _uow;

    public SetTicketPriorityHandler(ITicketRepository tickets, IUnitOfWork uow) =>
        (_tickets, _uow) = (tickets, uow);

    public async Task Handle(SetTicketPriorityCommand command, CancellationToken ct = default)
    {
        var ticket =
            await _tickets.GetByIdAsync(command.TicketId, ct)
            ?? throw new KeyNotFoundException("Ticket not found.");

        ticket.Priority = command.Priority;
        ticket.UpdatedAt = DateTime.Now;

        await _tickets.UpdateAsync(ticket, ct);
        await _uow.SaveChangesAsync(ct);
    }
}
