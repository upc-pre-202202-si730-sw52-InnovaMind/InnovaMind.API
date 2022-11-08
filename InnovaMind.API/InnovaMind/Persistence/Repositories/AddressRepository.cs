using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
namespace InnovaMind.API.InnovaMind.Persistence.Repositories;

public class AddressRepository : BaseRepository, IAddressRepository
{
    public AddressRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<IEnumerable<Address>> ListAsync()
    {
        return await _context.Address.ToListAsync();
    }

    public async Task AddAsync(Address address)
    {
        await _context.Address.AddAsync(address);
    }

    public async Task<Address> FindByIdAsync(int id)
    {
        return await _context.Address.FindAsync(id);
    }
    public async Task<Address> FindByNameAddressAsync(string nameAddress)
    {
        return await _context.Address
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.NameAddress == nameAddress);
    }

    public async Task<IEnumerable<Address>> FindByUserIdAsyn(int userId)
    {
        return await _context.Address
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public void Update(Address address)
    {
        _context.Address.Update(address);
    }

    public void Remove(Address address)
    {
        _context.Address.Remove(address);
    }
}
