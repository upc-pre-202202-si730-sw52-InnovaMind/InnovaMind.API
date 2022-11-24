using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;
 public class SchoolResponse : BaseResponse<School>
{
    public SchoolResponse(string message) : base (message)
    {

    }

    public SchoolResponse(School resource) : base (resource)
    {

    }
}