using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;
public interface ILicenseService
{
    Task<IEnumerable<License>> ListAsync();
    Task<License> GetByIdAsync(int id);
    Task<LicenseResponse> SaveAsync(License License);
    Task<LicenseResponse> UpdateAsync(int userId, License License);
    Task<LicenseResponse> DeleteAsync(int userId);
}
