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
            .Include(p => p.User)
            .ToListAsync();
    }
    public async Task<Recruiter> FindByIdAsync(int Id)
    {
        return await _context.Recruiters
            .FirstOrDefaultAsync(p => p.Id == Id);
    }
    public Recruiter FindById(int id)
    {
        return _context.Recruiters.Find(id);
    }
    public async Task<Recruiter> FindByUserIdAsync(int userid)
    {
        return await _context.Recruiters.SingleOrDefaultAsync(x => x.UserId == userid);
    }

    public async Task AddAsync(Recruiter recruiter)
    {
        await _context.Recruiters.AddAsync(recruiter);
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