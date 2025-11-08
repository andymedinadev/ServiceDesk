using ServiceDesk.Domain.Entities;

public record CreateTicketCommand(
    string Title,
    string Description,
    int CategoryId,
    int CreatedById,
    TicketPriority Priority = TicketPriority.Medium
);
