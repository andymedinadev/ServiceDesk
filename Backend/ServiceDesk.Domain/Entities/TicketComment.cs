namespace ServiceDesk.Domain.Entities;

public class TicketComment
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; } = default!;

    public int AuthorId { get; set; }
    public User Author { get; set; } = default!;

    public string Body { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
