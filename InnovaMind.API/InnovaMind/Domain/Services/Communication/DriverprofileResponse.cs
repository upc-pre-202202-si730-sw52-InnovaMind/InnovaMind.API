using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;
 public class DriverprofileResponse : BaseResponse<Driverprofile>
{
    public DriverprofileResponse(string message) : base (message)
    {

    }

    public DriverprofileResponse(Driverprofile resource) : base (resource)
    {

    }
}