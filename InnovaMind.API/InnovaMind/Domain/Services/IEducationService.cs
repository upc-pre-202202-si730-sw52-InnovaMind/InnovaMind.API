using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;
public interface IEducationService
{
    Task<IEnumerable<Education>> ListAsync();
    
    Task<EducationResponse> SaveAsync(Education Education);
    Task<EducationResponse> UpdateAsync(int userId, Education Education);
    Task<EducationResponse> DeleteAsync(int userId);
}
