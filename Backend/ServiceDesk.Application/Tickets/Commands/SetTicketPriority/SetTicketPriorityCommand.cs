using ServiceDesk.Domain.Entities;

public record SetTicketPriorityCommand(int TicketId, TicketPriority Priority, int ChangedById);
