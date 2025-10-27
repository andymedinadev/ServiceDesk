using ServiceDesk.Domain.Entities;

public record ChangeTicketStatusCommand(int TicketId, TicketStatus NewStatus, Guid ChangedById);
