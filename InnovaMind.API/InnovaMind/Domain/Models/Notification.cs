using InnovaMind.API.Security.Domain.Models;
namespace InnovaMind.API.InnovaMind.Domain.Models;

public class Notification
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    
    //Relationships
    public int UserId { get; set; }
    public User User { get; set; }
}