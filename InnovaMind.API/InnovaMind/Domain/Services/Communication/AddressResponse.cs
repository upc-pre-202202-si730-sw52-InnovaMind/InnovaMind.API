using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;
 public class AddressResponse : BaseResponse<Address>
{
    public AddressResponse(string message) : base (message)
    {

    }

    public AddressResponse(Address resource) : base (resource)
    {

    }
}