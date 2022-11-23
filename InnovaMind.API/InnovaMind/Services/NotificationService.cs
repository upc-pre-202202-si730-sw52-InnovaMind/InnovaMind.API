using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;
using InnovaMind.API.Security.Domain.Repositories;
using InnovaMind.API.Shared.Domain.Repositories;

namespace InnovaMind.API.InnovaMind.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    
    public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Notification>> GetNotificationsAsync()
    {
        return await _notificationRepository.GetNotificationsAsync();
    }
    
    public async Task<NotificationResponse> AddNotificationAsync(Notification notification)
    {
        var existingUser = await _userRepository.FindByIdAsync(notification.EmitterId);

        if (existingUser == null)
            return new NotificationResponse("Invalid User");

        try
        {
            //Add Notification
            await _notificationRepository.AddNotificationAsync(notification);
            await _unitOfWork.CompleteAsync();

            //Return response
            return new NotificationResponse(notification);
        }
        catch (Exception e)
        {
            //Error Handling
            return new NotificationResponse($"An error ocurred while saving the tutorial: {e.Message}");
        }
    }
    
    public async Task<IEnumerable<Notification>> GetLastNotificationRecruiter(int id)
    {
        return await _notificationRepository.GetLastNotificationRecruiter(id);
    }
    
    public async Task<IEnumerable<Notification>> GetLastNotificationDriver(int id)
    {
        return await _notificationRepository.GetLastNotificationDriver(id);
    }


    public async Task<NotificationResponse> DeleteAsync(int id)
    {
        var existingNotification = await _notificationRepository.FindNotificationByIdAsync(id);
        
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