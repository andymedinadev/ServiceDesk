using ServiceDesk.Domain.Entities;

public record SetTicketPriorityRequest(TicketPriority Priority, int ChangedById);
