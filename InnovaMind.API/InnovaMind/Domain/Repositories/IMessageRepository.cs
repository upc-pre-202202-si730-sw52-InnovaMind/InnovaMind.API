using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessagesAsync();
    
        Task AddMessageAsync(Message message);

        Task<Message> FindMessageByIdAsync(int messageId);
        
        Task<IEnumerable<Message>> GetLastMessageRecruiter(int id);

        Task<IEnumerable<Message>> GetLastMessageDriver(int id);
    }
}
