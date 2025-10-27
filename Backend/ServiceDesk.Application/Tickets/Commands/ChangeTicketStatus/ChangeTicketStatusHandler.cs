using ServiceDesk.Domain.Entities;

public class ChangeTicketStatusHandler
{
    private readonly ITicketRepository _tickets;
    private readonly IUnitOfWork _uow;

    public ChangeTicketStatusHandler(ITicketRepository tickets, IUnitOfWork uow) =>
        (_tickets, _uow) = (tickets, uow);

    public async Task Handle(ChangeTicketStatusCommand command, CancellationToken ct = default)
    {
        var ticket =
            await _tickets.GetByIdAsync(command.TicketId, ct)
            ?? throw new KeyNotFoundException("Ticket not found.");

        var previous = ticket.Status;

        if (previous == command.NewStatus)
            return;

        ticket.Status = command.NewStatus;
        ticket.UpdatedAt = DateTime.Now;

        if (command.NewStatus == TicketStatus.Closed)
        {
            ticket.ClosedAt = DateTime.Now;
        }

        ticket.StatusHistory.Add(
            new TicketStatusHistory
            {
                FromStatus = previous,
                ToStatus = command.NewStatus,
                ChangedAt = DateTime.Now,
                ChangedById = command.ChangedById,
            }
        );

        await _tickets.UpdateAsync(ticket, ct);
        await _uow.SaveChangesAsync(ct);
    }
}
