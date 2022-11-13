using InnovaMind.API.Security.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources
{
    public class MessageResource
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User Emitter { get; set; }
        public User Receiver { get; set; }
    }
}
