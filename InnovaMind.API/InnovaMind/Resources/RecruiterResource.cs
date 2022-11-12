using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Security.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;

public class RecruiterResource
{
    public int Id { get; set; }
    public User User { get; set; }
    public Company Company { get; set; }
    public IEnumerable<Post> Posts { get; set; }
}