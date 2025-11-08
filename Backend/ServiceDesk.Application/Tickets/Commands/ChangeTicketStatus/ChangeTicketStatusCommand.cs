using ServiceDesk.Domain.Entities;

public record ChangeTicketStatusCommand(int TicketId, TicketStatus NewStatus, int ChangedById);
