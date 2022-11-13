using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Shared.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services.Communication;

public class CompanyResponse : BaseResponse<Company>
{
    public CompanyResponse(Company resource) : base(resource)
    {
    }
    
    public CompanyResponse(string message) : base(message)
    {
    }
}