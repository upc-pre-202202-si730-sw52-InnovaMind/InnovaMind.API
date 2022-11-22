using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.InnovaMind.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InnovaMind.API.InnovaMind.Persistence.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync()
        {
            return await _context.Messages.Include(p => p.Emitter).Include(q => q.Receiver).ToListAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task<Message> FindMessageByIdAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<IEnumerable<Message>> GetLastMessageRecruiter(int id)
        {
            var lastMessage = await _context.Messages.FromSqlInterpolated($"SELECT * FROM messages m WHERE id IN (SELECT MAX(id) FROM messages WHERE emitter_id = {id} GROUP BY receiver_id)").Include(p => p.Receiver).ToListAsync();
            return lastMessage;
        }

        public async Task<IEnumerable<Message>> GetLastMessageDriver(int id)
        {
            var lastMessage = await _context.Messages.FromSqlInterpolated($"SELECT * FROM messages m WHERE id IN (SELECT MAX(id) FROM messages WHERE receiver_id = {id} GROUP BY emitter_id)").Include(p => p.Emitter).ToListAsync();
            return lastMessage;
        }
    }
}
