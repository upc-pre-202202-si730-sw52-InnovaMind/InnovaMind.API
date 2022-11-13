using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;

public class RecruiterResponse : BaseResponse<Recruiter>
{
    protected RecruiterResponse(string message) : base(message)
    {
    }

    protected RecruiterResponse(Recruiter resource) : base(resource)
    {
    }
}