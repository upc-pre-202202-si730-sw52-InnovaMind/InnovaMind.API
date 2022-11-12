using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;
 public class EducationResponse : BaseResponse<Education>
{
    public EducationResponse(string message) : base (message)
    {

    }

    public EducationResponse(Education resource) : base (resource)
    {

    }
}