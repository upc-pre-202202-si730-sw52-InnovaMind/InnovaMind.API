using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;
public interface IDriverprofileService
{
    Task<IEnumerable<Driverprofile>> ListAsync();
    
    Task<DriverprofileResponse> SaveAsync(Driverprofile Driverprofile);
    Task<DriverprofileResponse> UpdateAsync(int userId, Driverprofile Driverprofile);
    Task<DriverprofileResponse> DeleteAsync(int userId);
}
