using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;

public class NotificationResponse : BaseResponse<Notification>

{
    public NotificationResponse(Notification resource) : base(resource)
    {
    }
    
    public NotificationResponse(string message) : base(message)
    {
    }
}