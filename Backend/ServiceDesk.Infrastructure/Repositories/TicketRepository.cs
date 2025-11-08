using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain.Entities;

public class TicketRepository : ITicketRepository
{
    private readonly ServiceDeskDbContext _dbContext;

    public TicketRepository(ServiceDeskDbContext dbContext) => _dbContext = dbContext;

    public async Task AddAsync(Ticket ticket, CancellationToken ct = default)
    {
        await _dbContext.Tickets.AddAsync(ticket, ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var ticket = await _dbContext.Tickets.FindAsync(new object?[] { id }, ct);

        if (ticket is null)
        {
            return;
        }

        _dbContext.Tickets.Remove(ticket);
    }

    public async Task<IReadOnlyList<Ticket>> GetAllAsync(CancellationToken ct = default)
    {
        var tickets = await _dbContext
            .Tickets.Include(t => t.Category)
            .Include(t => t.Comments)
            .Include(t => t.Attachments)
            .Include(t => t.StatusHistory)
            .AsNoTracking()
            .ToListAsync(ct);

        return tickets;
    }

    public Task<Ticket?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return _dbContext
            .Tickets.Include(t => t.Category)
            .Include(t => t.Comments)
            .Include(t => t.Attachments)
            .Include(t => t.StatusHistory)
            .FirstOrDefaultAsync(t => t.Id == id, ct);
    }

    public Task UpdateAsync(Ticket ticket, CancellationToken ct = default)
    {
        _dbContext.Tickets.Update(ticket);
        return Task.CompletedTask;
    }
}
