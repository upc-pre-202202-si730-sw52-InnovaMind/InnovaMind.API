using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;
namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;
public class SocialNetworkResponse : BaseResponse<SocialNetwork>
{
    public SocialNetworkResponse(string message) : base(message)
    {

    }

    public SocialNetworkResponse(SocialNetwork resource) : base(resource)
    {

    }
}