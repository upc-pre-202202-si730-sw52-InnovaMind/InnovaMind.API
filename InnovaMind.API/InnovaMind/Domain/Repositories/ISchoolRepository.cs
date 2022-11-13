using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Repositories;
public interface ISchoolRepository
{
    Task<IEnumerable<School>> ListAsync();
    Task AddAsync(School school);
    Task<School> FindByIdAsync(int id);
    void Update(School school);
    void Remove(School school);
}
