using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Repositories;
public interface ILicenseRepository
{
    Task<IEnumerable<License>> ListAsync();
    Task AddAsync(License license);
    Task<License> FindByIdAsync(int id);
    void Update(License license);
    void Remove(License license);
}
