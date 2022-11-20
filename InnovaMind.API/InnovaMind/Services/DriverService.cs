using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;
using InnovaMind.API.Security.Domain.Repositories;
using InnovaMind.API.Shared.Domain.Repositories;

namespace InnovaMind.API.InnovaMind.Services;
public class DriverService : IDriverService
{
    private readonly IDriverRepository _DriverRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DriverService(IDriverRepository DriverRepository, IUnitOfWork unitOfWork)
    {
        _DriverRepository = DriverRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Driver>> ListAsync()
    {
        return await _DriverRepository.ListAsync();
    }

    public async Task<Driver> GetByIdAsync(int id)
    {
        var driver = await _DriverRepository.FindByIdAsync(id);
        if (driver == null) throw new KeyNotFoundException("User not found");
        return driver;
    }

    public async Task<DriverResponse> SaveAsync(Driver Driver)
    {
        try
        {
            await _DriverRepository.AddAsync(Driver);
            await _unitOfWork.CompleteAsync();
            return new DriverResponse(Driver);
        }
        catch (Exception e)
        {
            return new DriverResponse($"An error ocurred while saving the Driver: {e.Message}");
        }
    }

    public async Task<DriverResponse> UpdateAsync(int id, Driver Driver)
    {
        var existingDriver = await _DriverRepository.FindByIdAsync(id);

        if (existingDriver == null)
            return new DriverResponse("Driver not found");
        existingDriver.UserId = Driver.UserId;


        try
        {
            _DriverRepository.Update(existingDriver);
            await _unitOfWork.CompleteAsync();

            return new DriverResponse(existingDriver);
        }
        catch (Exception e)
        {
            return new DriverResponse($"An error ocurred while updating the Driver: {e.Message}");
        }
    }

    public async Task<DriverResponse> DeleteAsync(int id)
    {
        var existingDriver = await _DriverRepository.FindByIdAsync(id);

        if(existingDriver == null)
            return new DriverResponse("Driver not found");
        try
        {
            _DriverRepository.Remove(existingDriver);
            await _unitOfWork.CompleteAsync();
            return new DriverResponse(existingDriver);
        }
        catch (Exception e)
        {
            return new DriverResponse($"An error ocurred while deleting the Driver: {e.Message}");
        }
    }
    private Driver GetById(int id)
    {
        var user = _DriverRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}