namespace POS.Infraestructure.Persistences.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly POSContext _context;
    public ICategoryRepository Category { get; private set; }

    public UnitOfWork(POSContext context)
    {
        _context = context;
        Category = new CategoryRepository(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}

