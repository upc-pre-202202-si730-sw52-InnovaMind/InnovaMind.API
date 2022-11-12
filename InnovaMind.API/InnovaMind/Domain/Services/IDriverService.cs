using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;
public interface IDriverService
{
    Task<IEnumerable<Driver>> ListAsync();
    
    Task<DriverResponse> SaveAsync(Driver Driver);
    Task<DriverResponse> UpdateAsync(int id, Driver Driver);
    Task<DriverResponse> DeleteAsync(int id);
}
