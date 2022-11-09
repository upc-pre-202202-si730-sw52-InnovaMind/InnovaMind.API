using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;

public interface IRecruiterService
{
    Task<IEnumerable<Recruiter>> ListAsync();
    Task<RecruiterResponse> SaveAsync(Recruiter recruiter);
    Task<RecruiterResponse> UpdateAsync(int id, Recruiter recruiter);
    Task<RecruiterResponse> DeleteAsync(int id);
}