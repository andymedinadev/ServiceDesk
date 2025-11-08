using ServiceDesk.Domain.Entities;

public class GetTicketsHandler(ITicketRepository tickets)
{
    private readonly ITicketRepository _tickets = tickets;

    public async Task<IReadOnlyList<TicketSummaryDto>> Handle(
        GetTicketsQuery query,
        CancellationToken ct = default
    )
    {
        var tickets = await _tickets.GetAllAsync(ct);

        var filtered = query.IncludeClose
            ? tickets
            : tickets.Where(t => t.Status != TicketStatus.Closed).ToList();

        var summaries = filtered
            .Select(t => new TicketSummaryDto(
                t.Id,
                t.Title,
                t.Category?.Name ?? string.Empty,
                t.Status,
                t.Priority,
                t.CreatedAt,
                t.UpdatedAt,
                t.ClosedAt
            ))
            .ToList();

        return summaries;
    }
}
