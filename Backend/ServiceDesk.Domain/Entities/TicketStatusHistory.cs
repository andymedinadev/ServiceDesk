namespace ServiceDesk.Domain.Entities;

public class TicketStatusHistory
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; } = default!;

    public TicketStatus FromStatus { get; set; }
    public TicketStatus ToStatus { get; set; }
    public int ChangedById { get; set; }
    public User ChangedBy { get; set; } = default!;
    public DateTime ChangedAt { get; set; } = DateTime.Now;
}
