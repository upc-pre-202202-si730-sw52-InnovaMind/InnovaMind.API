using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;
namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;
public class UserResponse : BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {

    }

    public UserResponse(User resource) : base(resource)
    {

    }
}