using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;
using InnovaMind.API.Shared.Domain.Repositories;

namespace InnovaMind.API.InnovaMind.Services;
public class SocialNetworkService : ISocialNetworkService
{
    private readonly ISocialNetworkRepository _socialNetworkRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SocialNetworkService(ISocialNetworkRepository socialNetworkRepository, IUnitOfWork unitOfWork)
    {
        _socialNetworkRepository = socialNetworkRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SocialNetwork>> ListAsync()
    {
        return await _socialNetworkRepository.ListAsync();
    }

    public async Task<SocialNetworkResponse> SaveAsync(SocialNetwork socialNetwork)
    {
        try
        {
            await _socialNetworkRepository.AddAsync(socialNetwork);
            await _unitOfWork.CompleteAsync();
            return new SocialNetworkResponse(socialNetwork);
        }
        catch (Exception e)
        {
            return new SocialNetworkResponse($"An error ocurred while saving the social Network: {e.Message}");
        }
    }

    public async Task<SocialNetworkResponse> UpdateAsync(int id, SocialNetwork socialNetwork)
    {
        var existingSocialNetwork = await _socialNetworkRepository.FindByIdAsync(id);

        if (existingSocialNetwork == null)
            return new SocialNetworkResponse("Social Network not found");
        existingSocialNetwork.NameSocialNetwork = socialNetwork.NameSocialNetwork;
        existingSocialNetwork.UrlSocialNetwork = socialNetwork.UrlSocialNetwork;
        
        try
        {
            _socialNetworkRepository.Update(existingSocialNetwork);
            await _unitOfWork.CompleteAsync();

            return new SocialNetworkResponse(existingSocialNetwork);
        }
        catch (Exception e)
        {
            return new SocialNetworkResponse($"An error ocurred while updating the Social network: {e.Message}");
        }
    }

    public async Task<SocialNetworkResponse> DeleteAsync(int id)
    {
        var existingSocialNetwork = await _socialNetworkRepository.FindByIdAsync(id);

        if(existingSocialNetwork == null)
            return new SocialNetworkResponse("Social network not found");
        try
        {
            _socialNetworkRepository.Remove(existingSocialNetwork);
            await _unitOfWork.CompleteAsync();
            return new SocialNetworkResponse(existingSocialNetwork);
        }
        catch (Exception e)
        {
            return new SocialNetworkResponse($"An error ocurred while deleting the social network: {e.Message}");
        }
    }
}