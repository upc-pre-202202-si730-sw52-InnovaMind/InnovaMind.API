using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;

public interface INotificationService
{
    Task<IEnumerable<Notification>> ListAsync();
    Task<NotificationResponse> SaveAsync(Notification notification);
    Task<NotificationResponse> UpdateAsync(int id, Notification notification);
    Task<NotificationResponse> DeleteAsync(int id);
    
}