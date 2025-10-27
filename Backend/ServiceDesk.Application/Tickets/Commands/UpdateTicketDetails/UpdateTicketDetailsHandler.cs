public class UpdateTicketDetailsHandler
{
    private readonly ITicketRepository _tickets;
    private readonly IUnitOfWork _uow;

    public UpdateTicketDetailsHandler(ITicketRepository tickets, IUnitOfWork uow) =>
        (_tickets, _uow) = (tickets, uow);

    public async Task Handle(UpdateTicketDetailsCommand command, CancellationToken ct = default)
    {
        var ticket =
            await _tickets.GetByIdAsync(command.TicketId, ct)
            ?? throw new KeyNotFoundException("Ticket not found.");

        ticket.Title = command.Title.Trim();
        ticket.Description = command.Description.Trim();
        ticket.CategoryId = command.CategoryId;
        ticket.UpdatedAt = DateTime.Now;

        await _tickets.UpdateAsync(ticket, ct);
        await _uow.SaveChangesAsync(ct);
    }
}
