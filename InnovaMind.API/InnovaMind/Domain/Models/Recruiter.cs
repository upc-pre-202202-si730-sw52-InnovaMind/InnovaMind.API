using InnovaMind.API.Security.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Models;

public class Recruiter
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CompanyId { get; set; }
    
    public User User { get; set; }
    public Company Company { get; set; }
    public IEnumerable<Post> Posts { get; set; }
}