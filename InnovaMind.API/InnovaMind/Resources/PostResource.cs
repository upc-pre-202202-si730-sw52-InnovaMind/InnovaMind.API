using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;

public class PostResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Amount { get; set; }
    public string Category { get; set; }
    public string location { get; set; }
    public int Time { get; set; }
    public string ImagenURL { get; set; }
    public DateTime date { get; set; }
    public Recruiter Recruiter { get; set; }
}