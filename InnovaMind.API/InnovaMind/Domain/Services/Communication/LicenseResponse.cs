using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;
 public class LicenseResponse : BaseResponse<License>
{
    public LicenseResponse(string message) : base (message)
    {

    }

    public LicenseResponse(License resource) : base (resource)
    {

    }
}