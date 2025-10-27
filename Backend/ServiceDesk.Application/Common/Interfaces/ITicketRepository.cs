using ServiceDesk.Domain.Entities;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task AddAsync(Ticket ticket, CancellationToken ct = default);
    Task UpdateAsync(Ticket ticket, CancellationToken ct = default);
    Task DeleteAsync(Guid id);
}
