using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;
public interface IAddressService
{
    Task<IEnumerable<Address>> ListAsync();
    Task<IEnumerable<Address>> ListByUserIdAsync(int userId);
    Task<AddressResponse> SaveAsync(Address address);
    Task<AddressResponse> UpdateAsync(int userId, Address address);
    Task<AddressResponse> DeleteAsync(int userId);
}
