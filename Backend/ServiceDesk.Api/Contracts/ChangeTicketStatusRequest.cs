using ServiceDesk.Domain.Entities;

public record ChangeTicketStatusRequest(TicketStatus NewStatus, int ChangeById);
