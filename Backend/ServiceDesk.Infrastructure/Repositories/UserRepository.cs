using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain.Entities;

public class UserRepository : IUserRepository
{
    private readonly ServiceDeskDbContext _dbContext;

    public UserRepository(ServiceDeskDbContext dbContext) => _dbContext = dbContext;

    public Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
    }
}
