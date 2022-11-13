using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;
using InnovaMind.API.Shared.Domain.Repositories;

namespace InnovaMind.API.InnovaMind.Services;
public class DriverprofileService : IDriverprofileService
{
    private readonly IDriverprofileRepository _DriverprofileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DriverprofileService(IDriverprofileRepository DriverprofileRepository, IUnitOfWork unitOfWork)
    {
        _DriverprofileRepository = DriverprofileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Driverprofile>> ListAsync()
    {
        return await _DriverprofileRepository.ListAsync();
    }

    public async Task<DriverprofileResponse> SaveAsync(Driverprofile Driverprofile)
    {
        try
        {
            await _DriverprofileRepository.AddAsync(Driverprofile);
            await _unitOfWork.CompleteAsync();
            return new DriverprofileResponse(Driverprofile);
        }
        catch (Exception e)
        {
            return new DriverprofileResponse($"An error ocurred while saving the social Network: {e.Message}");
        }
    }

    public async Task<DriverprofileResponse> UpdateAsync(int id, Driverprofile Driverprofile)
    {
        var existingDriverprofile = await _DriverprofileRepository.FindByIdAsync(id);

        if (existingDriverprofile == null)
            return new DriverprofileResponse("Social Network not found");
        existingDriverprofile.DriverId = Driverprofile.DriverId;
        existingDriverprofile.LicenseId = Driverprofile.LicenseId;
        
        try
        {
            _DriverprofileRepository.Update(existingDriverprofile);
            await _unitOfWork.CompleteAsync();

            return new DriverprofileResponse(existingDriverprofile);
        }
        catch (Exception e)
        {
            return new DriverprofileResponse($"An error ocurred while updating the Social network: {e.Message}");
        }
    }

    public async Task<DriverprofileResponse> DeleteAsync(int id)
    {
        var existingDriverprofile = await _DriverprofileRepository.FindByIdAsync(id);

        if(existingDriverprofile == null)
            return new DriverprofileResponse("Social network not found");
        try
        {
            _DriverprofileRepository.Remove(existingDriverprofile);
            await _unitOfWork.CompleteAsync();
            return new DriverprofileResponse(existingDriverprofile);
        }
        catch (Exception e)
        {
            return new DriverprofileResponse($"An error ocurred while deleting the social network: {e.Message}");
        }
    }
}