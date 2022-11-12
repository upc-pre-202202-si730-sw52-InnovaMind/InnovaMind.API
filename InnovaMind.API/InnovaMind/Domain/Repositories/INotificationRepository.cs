using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Repositories;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> ListAsync();
    Task AddAsync(Notification notification);
    Task<Notification> FindByIdAsync(int id);
    void Update(Notification notification);
    void Remove(Notification notification);
}