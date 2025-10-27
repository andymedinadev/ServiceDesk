using ServiceDesk.Domain.Entities;

public class AddTicketAttachmentHandler
{
    private readonly ITicketRepository _tickets;
    private readonly IAttachmentStorage _storage;
    private readonly IUnitOfWork _uow;

    public AddTicketAttachmentHandler(
        ITicketRepository tickets,
        IAttachmentStorage storage,
        IUnitOfWork uow
    ) => (_tickets, _storage, _uow) = (tickets, storage, uow);

    public async Task<int> Handle(
        AddTicketAttachmentCommand command,
        CancellationToken ct = default
    )
    {
        var ticket =
            await _tickets.GetByIdAsync(command.TicketId)
            ?? throw new KeyNotFoundException("Ticket not found.");

        var location = await _storage.SaveAsync(command.FileName, command.Content, ct);

        var attachment = new TicketAttachment
        {
            TicketId = ticket.Id,
            FileName = command.FileName,
            StoragePath = location,
            UploadedById = command.UploadedById,
            CreatedAt = DateTime.Now,
        };

        ticket.Attachments.Add(attachment);
        ticket.UpdatedAt = DateTime.Now;

        await _tickets.UpdateAsync(ticket, ct);
        await _uow.SaveChangesAsync(ct);

        return attachment.Id;
    }
}
