using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;
using InnovaMind.API.Shared.Domain.Repositories;

namespace InnovaMind.API.InnovaMind.Services;

public class RecruiterService : IRecruiterService
{
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public RecruiterService(IRecruiterRepository recruiterRepository, IUnitOfWork unitOfWork)
    {
        _recruiterRepository = recruiterRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Recruiter>> ListAsync()
    {
        return await _recruiterRepository.ListAsync();
    }

    public async Task<RecruiterResponse> SaveAsync(Recruiter recruiter)
    {
        try
        {
            await _recruiterRepository.AddAsync(recruiter);
            await _unitOfWork.CompleteAsync();
            return new RecruiterResponse(recruiter);
        }
        catch (Exception e)
        {
            return new RecruiterResponse($"An error occurred when saving the recruiter: {e.Message}");
        }
    }

    public async Task<RecruiterResponse> UpdateAsync(int id, Recruiter recruiter)
    {
        var existingRecruiter = await _recruiterRepository.FindByIdAsync(id);
        if (existingRecruiter == null)
            return new RecruiterResponse("Recruiter not found.");
        existingRecruiter.CompanyId = recruiter.CompanyId;
        existingRecruiter.UserId = recruiter.UserId;
        try 
        {
            _recruiterRepository.Update(existingRecruiter);
            await _unitOfWork.CompleteAsync();
            return new RecruiterResponse(existingRecruiter);
        }
        catch (Exception e)
        {
            return new RecruiterResponse($"An error occurred when updating the recruiter: {e.Message}");
        }
    }

    public async Task<RecruiterResponse> DeleteAsync(int id)
    {
        var existingRecruiter = await _recruiterRepository.FindByIdAsync(id);
        if (existingRecruiter == null)
            return new RecruiterResponse("Recruiter not found.");
        try
        {
            _recruiterRepository.Remove(existingRecruiter);
            await _unitOfWork.CompleteAsync();
            return new RecruiterResponse(existingRecruiter);
        }
        catch (Exception e)
        {
            return new RecruiterResponse($"An error occurred when deleting the recruiter: {e.Message}");
        }
    }
}