using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;

public class RecruiterResponse : BaseResponse<Recruiter>
{
    public RecruiterResponse(string message) : base(message)
    {
    }

    public RecruiterResponse(Recruiter resource) : base(resource)
    {
    }
}