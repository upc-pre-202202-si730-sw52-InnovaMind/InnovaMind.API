using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Repositories;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetNotificationsAsync();
    Task AddNotificationAsync(Notification notification);
    Task<Notification> FindNotificationByIdAsync(int notificationId);    
    void Remove(Notification notification);

}