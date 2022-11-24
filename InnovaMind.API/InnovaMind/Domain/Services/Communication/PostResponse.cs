using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;

public class PostResponse : BaseResponse<Post>
{
    public PostResponse(Post resource) : base(resource)
    {
    }
    
    public PostResponse(string message) : base(message)
    {
    }
}