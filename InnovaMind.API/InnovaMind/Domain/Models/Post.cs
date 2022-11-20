using System.Text.Json.Serialization;

namespace InnovaMind.API.InnovaMind.Domain.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime date { get; set; }
    public int RecruiterId { get; set; }
    [JsonIgnore]
    public Recruiter Recruiter { get; set; }
}