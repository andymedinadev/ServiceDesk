public class UnitOfWork : IUnitOfWork
{
    private readonly ServiceDeskDbContext _dbContext;

    public UnitOfWork(ServiceDeskDbContext dbContext) => _dbContext = dbContext;

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return _dbContext.SaveChangesAsync(ct);
    }
}
