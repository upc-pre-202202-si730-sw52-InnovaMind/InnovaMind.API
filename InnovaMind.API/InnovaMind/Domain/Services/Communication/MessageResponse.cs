using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;

 public class MessageResponse : BaseResponse<Message>
{
    public MessageResponse(string message) : base(message)
    {

    }

    public MessageResponse(Message resource) : base(resource)
    {

    }
}
