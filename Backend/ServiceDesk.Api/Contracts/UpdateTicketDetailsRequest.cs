public record UpdateTicketDetailsRequest(
    string Title,
    string Description,
    int CategoryId,
    int UpdatedById
);
