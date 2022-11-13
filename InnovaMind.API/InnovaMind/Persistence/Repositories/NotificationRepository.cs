using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

namespace InnovaMind.API.InnovaMind.Persistence.Repositories;

public class NotificationRepository : BaseRepository, INotificationRepository
{
    public NotificationRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Notification>> ListAsync()
    {
        return await _context.Notifications.Include(p => p.User).ToListAsync();
    }
    
    public async Task AddAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
    }
    
    public async Task<Notification> FindByIdAsync(int id)
    {
        return await _context.Notifications.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public void Update(Notification notification)
    {
        _context.Notifications.Update(notification);
    }
    public void Remove(Notification notification)
    {
        _context.Notifications.Remove(notification);
    }
}