using ServiceDesk.Domain.Entities;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<Ticket>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Ticket ticket, CancellationToken ct = default);
    Task UpdateAsync(Ticket ticket, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}
