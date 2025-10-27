public record AssignTicketCommand(int TicketId, Guid? AssignedToId, Guid ChangedById);
