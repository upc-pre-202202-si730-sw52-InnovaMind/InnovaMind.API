using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

namespace InnovaMind.API.InnovaMind.Persistence.Repositories;
public class SchoolRepository : BaseRepository, ISchoolRepository
{
    public SchoolRepository(AppDbContext context) : base(context)
    {

    }
    
    public async Task<IEnumerable<School>> ListAsync()
    {
        return await _context.Schools
            .Include(p => p.Education)
            .ToListAsync();
    }

    public async Task AddAsync(School School)
    {
        await _context.Schools.AddAsync(School);
    }

    public async Task<School> FindByIdAsync(int SchoolId)
    {
        return await _context.Schools
            .Include(p => p.Education)
            .FirstOrDefaultAsync(p => p.Id == SchoolId);
    }
    
    public void Update(School School)
    {
        _context.Schools.Update(School);
    }

    public void Remove(School School)
    {
        _context.Schools.Remove(School);
    }
}
