using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

namespace InnovaMind.API.InnovaMind.Persistence.Repositories;
public class SocialNetworkRepository : BaseRepository, ISocialNetworkRepository
{
    public SocialNetworkRepository(AppDbContext context) : base(context)
    {

    }
    
    public async Task<IEnumerable<SocialNetwork>> ListAsync()
    {
        return await _context.SocialNetworks
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(SocialNetwork socialNetwork)
    {
        await _context.SocialNetworks.AddAsync(socialNetwork);
    }

    public async Task<SocialNetwork> FindByIdAsync(int socialNetworkId)
    {
        return await _context.SocialNetworks
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == socialNetworkId);
    }
    
    public void Update(SocialNetwork socialNetwork)
    {
        _context.SocialNetworks.Update(socialNetwork);
    }

    public void Remove(SocialNetwork socialNetwork)
    {
        _context.SocialNetworks.Remove(socialNetwork);
    }
}
