using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

namespace InnovaMind.API.InnovaMind.Persistence.Repositories;
public class EducationRepository : BaseRepository, IEducationRepository
{
    public EducationRepository(AppDbContext context) : base(context)
    {

    }
    
    public async Task<IEnumerable<Education>> ListAsync()
    {
        return await _context.Educations
            .Include(p => p.Driverprofile)
            .ToListAsync();
    }

    public async Task AddAsync(Education Education)
    {
        await _context.Educations.AddAsync(Education);
    }

    public async Task<Education> FindByIdAsync(int EducationId)
    {
        return await _context.Educations
            .Include(p => p.Driverprofile)
            .FirstOrDefaultAsync(p => p.Id == EducationId);
    }
    
    public void Update(Education Education)
    {
        _context.Educations.Update(Education);
    }

    public void Remove(Education Education)
    {
        _context.Educations.Remove(Education);
    }
}
