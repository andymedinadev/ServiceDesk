public class GetTicketByIdHandler(ITicketRepository tickets)
{
    private readonly ITicketRepository _tickets = tickets;

    public async Task<TicketDetailDto?> Handle(
        GetTicketByIdQuery query,
        CancellationToken ct = default
    )
    {
        var ticket = await _tickets.GetByIdAsync(query.Id, ct);

        if (ticket is null)
        {
            return null;
        }

        var comments = ticket
            .Comments.OrderBy(c => c.CreatedAt)
            .Select(c => new TicketCommentDto(c.Id, c.AuthorId, c.Body, c.CreatedAt))
            .ToList();

        var attachments = ticket
            .Attachments.OrderBy(a => a.CreatedAt)
            .Select(a => new TicketAttachmentDto(
                a.Id,
                a.FileName,
                a.ContentType,
                a.SizeBytes,
                a.UploadedById,
                a.CreatedAt
            ))
            .ToList();

        var statusHistory = ticket
            .StatusHistory.OrderBy(h => h.ChangedAt)
            .Select(h => new TicketStatusHistoryDto(
                h.Id,
                h.FromStatus,
                h.ToStatus,
                h.ChangedById,
                h.ChangedAt
            ))
            .ToList();

        var detail = new TicketDetailDto(
            ticket.Id,
            ticket.Title,
            ticket.Description,
            ticket.Category?.Name ?? string.Empty,
            ticket.Status,
            ticket.Priority,
            ticket.CreatedById,
            ticket.AssignedToId,
            ticket.CreatedAt,
            ticket.UpdatedAt,
            ticket.ClosedAt,
            comments,
            attachments,
            statusHistory
        );

        return detail;
    }
}
