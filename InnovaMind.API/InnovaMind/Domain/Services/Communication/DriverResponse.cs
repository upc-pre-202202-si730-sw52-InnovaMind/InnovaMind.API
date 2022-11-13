using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;
 public class DriverResponse : BaseResponse<Driver>
{
    public DriverResponse(string message) : base (message)
    {

    }

    public DriverResponse(Driver resource) : base (resource)
    {

    }
}