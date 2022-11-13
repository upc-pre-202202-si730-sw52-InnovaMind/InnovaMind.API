using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

namespace InnovaMind.API.InnovaMind.Persistence.Repositories;

public class RecruiterRepository : BaseRepository, IRecruiterRepository
{
    public RecruiterRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Recruiter>> ListAsync()
    {
        return await _context.Recruiters
            .Include(p => p.Company)
            .ToListAsync();
    }

    public async Task AddAsync(Recruiter recruiter)
    {
        await _context.Recruiters.AddAsync(recruiter);
    }

    public async Task<Recruiter> FindByIdAsync(int id)
    {
        return await _context.Recruiters
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public void Update(Recruiter recruiter)
    {
        _context.Recruiters.Update(recruiter);
    }

    public void Remove(Recruiter recruiter)
    {
        _context.Recruiters.Remove(recruiter);
    }
}