using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;

 public interface IMessageService
 {
     Task<IEnumerable<Message>> GetMessagesAsync();

     Task<MessageResponse> AddMessageAsync(Message message);

     Task<IEnumerable<Message>> GetLastMessageRecruiter(int id);

     Task<IEnumerable<Message>> GetLastMessageDriver(int id);
}

