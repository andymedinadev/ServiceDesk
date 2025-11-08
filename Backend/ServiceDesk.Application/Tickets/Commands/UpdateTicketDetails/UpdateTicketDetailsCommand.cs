public record UpdateTicketDetailsCommand(
    int TicketId,
    string Title,
    string Description,
    int CategoryId,
    int UpdatedById
);
