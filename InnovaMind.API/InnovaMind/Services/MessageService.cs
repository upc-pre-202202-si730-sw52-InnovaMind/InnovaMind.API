using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;
using InnovaMind.API.Security.Domain.Repositories;
using InnovaMind.API.Shared.Domain.Repositories;

namespace InnovaMind.API.InnovaMind.Services;
public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _messageRepository = messageRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Message>> GetMessagesAsync()
    {
        return await _messageRepository.GetMessagesAsync();
    }

    public async Task<MessageResponse> AddMessageAsync(Message message)
    {
        var existingUser = await _userRepository.FindByIdAsync(message.EmitterId);

        if (existingUser == null)
            return new MessageResponse("Invalid User");

        try
        {
            //Add Message
            await _messageRepository.AddMessageAsync(message);
            await _unitOfWork.CompleteAsync();

            //Return response
            return new MessageResponse(message);
        }
        catch (Exception e)
        {
            //Error Handling
            return new MessageResponse($"An error ocurred while saving the tutorial: {e.Message}");
        }
    }
}


