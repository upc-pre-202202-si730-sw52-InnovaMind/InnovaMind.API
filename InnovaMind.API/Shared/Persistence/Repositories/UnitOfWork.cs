using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
namespace InnovaMind.API.Shared.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}