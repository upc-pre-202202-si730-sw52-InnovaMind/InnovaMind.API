using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;
public interface ISchoolService
{
    Task<IEnumerable<School>> ListAsync();
    
    Task<SchoolResponse> SaveAsync(School School);
    Task<SchoolResponse> UpdateAsync(int userId, School School);
    Task<SchoolResponse> DeleteAsync(int userId);
}
