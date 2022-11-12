using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;
using InnovaMind.API.Shared.Domain.Repositories;

namespace InnovaMind.API.InnovaMind.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Notification>> ListAsync()
    {
        return await _notificationRepository.ListAsync();
    }
    
    public async Task<NotificationResponse> SaveAsync(Notification notification)
    {
        try
        {
            await _notificationRepository.AddAsync(notification);
            await _unitOfWork.CompleteAsync();
            
            return new NotificationResponse(notification);
        }
        catch (Exception ex)
        {
            return new NotificationResponse($"An error occurred when saving the notification: {ex.Message}");
        }
    }
    
    public async Task<NotificationResponse> UpdateAsync(int id, Notification notification)
    {
        var existingNotification = await _notificationRepository.FindByIdAsync(id);
        
        if (existingNotification == null)
            return new NotificationResponse("Notification not found.");
        
        existingNotification.Date = notification.Date;
        existingNotification.Content = notification.Content;
        existingNotification.UserId = notification.UserId;
        
        try
        {
            _notificationRepository.Update(existingNotification);
            await _unitOfWork.CompleteAsync();
            
            return new NotificationResponse(existingNotification);
        }
        catch (Exception e)
        {
            return new NotificationResponse($"An error occurred when updating the notification: {e.Message}");
        }
    }
    
    public async Task<NotificationResponse> DeleteAsync(int id)
    {
        var existingNotification = await _notificationRepository.FindByIdAsync(id);
        
        if (existingNotification == null)
            return new NotificationResponse("Notification not found.");
        
        try
        {
            _notificationRepository.Remove(existingNotification);
            await _unitOfWork.CompleteAsync();
            
            return new NotificationResponse(existingNotification);
        }
        catch (Exception e)
        {
            return new NotificationResponse($"An error occurred when deleting the notification: {e.Message}");
        }
    }
}