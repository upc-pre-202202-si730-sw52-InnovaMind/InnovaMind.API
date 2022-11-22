using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;
using InnovaMind.API.Shared.Domain.Repositories;

namespace InnovaMind.API.InnovaMind.Services;
public class LicenseService : ILicenseService
{
    private readonly ILicenseRepository _LicenseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LicenseService(ILicenseRepository LicenseRepository, IUnitOfWork unitOfWork)
    {
        _LicenseRepository = LicenseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<License>> ListAsync()
    {
        return await _LicenseRepository.ListAsync();
    }

    public async Task<LicenseResponse> SaveAsync(License License)
    {
        try
        {
            await _LicenseRepository.AddAsync(License);
            await _unitOfWork.CompleteAsync();
            return new LicenseResponse(License);
        }
        catch (Exception e)
        {
            return new LicenseResponse($"An error ocurred while saving the social Network: {e.Message}");
        }
    }
    public async Task<License> GetByIdAsync(int id)
    {
        var license = await _LicenseRepository.FindByIdAsync(id);
        if (license == null) throw new KeyNotFoundException("license not found");
        return license;
    }

    public async Task<LicenseResponse> UpdateAsync(int id, License License)
    {
        var existingLicense = await _LicenseRepository.FindByIdAsync(id);

        if (existingLicense == null)
            return new LicenseResponse("Social Network not found");
        existingLicense.Gategory = License.Gategory;
        existingLicense.Description = License.Description;
        
        try
        {
            _LicenseRepository.Update(existingLicense);
            await _unitOfWork.CompleteAsync();

            return new LicenseResponse(existingLicense);
        }
        catch (Exception e)
        {
            return new LicenseResponse($"An error ocurred while updating the Social network: {e.Message}");
        }
    }

    public async Task<LicenseResponse> DeleteAsync(int id)
    {
        var existingLicense = await _LicenseRepository.FindByIdAsync(id);

        if(existingLicense == null)
            return new LicenseResponse("Social network not found");
        try
        {
            _LicenseRepository.Remove(existingLicense);
            await _unitOfWork.CompleteAsync();
            return new LicenseResponse(existingLicense);
        }
        catch (Exception e)
        {
            return new LicenseResponse($"An error ocurred while deleting the social network: {e.Message}");
        }
    }
}