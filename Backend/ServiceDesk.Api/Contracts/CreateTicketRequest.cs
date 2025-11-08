using ServiceDesk.Domain.Entities;

public record CreateTicketRequest(
    string Title,
    string Description,
    int CategoryId,
    int CreatedById,
    TicketPriority Priority = TicketPriority.Medium
);
