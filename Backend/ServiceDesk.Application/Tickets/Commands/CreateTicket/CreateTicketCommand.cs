using ServiceDesk.Domain.Entities;

public record CreateTicketCommand(
    string Title,
    string Description,
    int CategoryId,
    Guid CreatedById,
    TicketPriority Priority = TicketPriority.Medium
);
