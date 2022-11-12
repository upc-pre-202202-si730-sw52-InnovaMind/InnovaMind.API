using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;

public interface ICompanyService
{
    Task<IEnumerable<Company>> ListAsync();
    Task<Company> FindByIdAsync(int id);
    Task<CompanyResponse> SaveAsync(Company company);
    Task<CompanyResponse> UpdateAsync(int id, Company company);
    Task<CompanyResponse> DeleteAsync(int id);
}