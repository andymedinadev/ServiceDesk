using ServiceDesk.Domain.Entities;

public class CloseTicketHandler
{
    private readonly ChangeTicketStatusHandler _changeStatus;

    public CloseTicketHandler(ChangeTicketStatusHandler changeStatus) =>
        _changeStatus = changeStatus;

    public Task Handle(CloseTicketCommand command, CancellationToken ct = default) =>
        _changeStatus.Handle(
            new ChangeTicketStatusCommand(
                command.TicketId,
                TicketStatus.Closed,
                command.ClosedById
            ),
            ct
        );
}
