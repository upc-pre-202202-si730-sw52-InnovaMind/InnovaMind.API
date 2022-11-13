using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Repositories;
public interface IEducationRepository
{
    Task<IEnumerable<Education>> ListAsync();
    Task AddAsync(Education education);
    Task<Education> FindByIdAsync(int id);
    void Update(Education education);
    void Remove(Education education);
}
