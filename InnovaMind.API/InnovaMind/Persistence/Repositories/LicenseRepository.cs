using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

namespace InnovaMind.API.InnovaMind.Persistence.Repositories;
public class LicenseRepository : BaseRepository, ILicenseRepository
{
    public LicenseRepository(AppDbContext context) : base(context)
    {

    }
    
    public async Task<IEnumerable<License>> ListAsync()
    {
        return await _context.Licenses
            .Include(p => p.Driverprofile)
            .ToListAsync();
    }

    public async Task AddAsync(License License)
    {
        await _context.Licenses.AddAsync(License);
    }

    public async Task<License> FindByIdAsync(int LicenseId)
    {
        return await _context.Licenses
            .Include(p => p.Driverprofile)
            .FirstOrDefaultAsync(p => p.Id == LicenseId);
    }
    
    public void Update(License License)
    {
        _context.Licenses.Update(License);
    }

    public void Remove(License License)
    {
        _context.Licenses.Remove(License);
    }
}
