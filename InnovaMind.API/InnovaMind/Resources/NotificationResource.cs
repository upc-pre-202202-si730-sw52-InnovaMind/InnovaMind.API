using InnovaMind.API.Security.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;

public class NotificationResource
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime date { get; set; }
    
    //Relationships
    public User User { get; set; }
}