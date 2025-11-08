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

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Ticket>> GetAllAsync()
    {
        throw new NotImplementedException();
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
