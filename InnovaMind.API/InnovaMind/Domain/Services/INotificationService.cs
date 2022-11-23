using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;

public interface INotificationService
{
    Task<IEnumerable<Notification>> GetNotificationsAsync();
    Task<NotificationResponse> AddNotificationAsync(Notification notification);
    Task<IEnumerable<Notification>> GetLastNotificationRecruiter(int id);
    Task<IEnumerable<Notification>> GetLastNotificationDriver(int id);
    
    Task<NotificationResponse> DeleteAsync(int id);

}