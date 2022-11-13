using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Repositories;

public interface IRecruiterRepository
{
    Task<IEnumerable<Recruiter>> ListAsync();
    Task AddAsync(Recruiter recruiter);
    Task<Recruiter> FindByIdAsync(int id);
    void Update(Recruiter recruiter);
    void Remove(Recruiter recruiter);
}