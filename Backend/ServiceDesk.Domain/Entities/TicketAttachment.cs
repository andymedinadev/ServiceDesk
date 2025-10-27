namespace ServiceDesk.Domain.Entities;

public class TicketAttachment
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; } = default!;

    public Guid UploadedById { get; set; }
    public User UploadedBy { get; set; } = default!;

    public string FileName { get; set; } = default!;
    public string ContentType { get; set; } = default!;
    public long SizeBytes { get; set; }
    public string StoragePath { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
