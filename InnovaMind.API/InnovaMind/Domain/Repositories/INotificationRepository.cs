using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Repositories;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetNotificationsAsync();
    Task AddNotificationAsync(Notification notification);
    Task<Notification> FindNotificationByIdAsync(int notificationId);

    Task<IEnumerable<Notification>> GetLastNotificationRecruiter(int id);
    Task<IEnumerable<Notification>> GetLastNotificationDriver(int id);
    
    void Remove(Notification notification);

}