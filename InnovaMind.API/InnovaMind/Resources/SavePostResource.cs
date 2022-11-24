using System.ComponentModel.DataAnnotations;
using InnovaMind.API.Security.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;

public class SavePostResource
{
    [Required]
    public int RecruiterId { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public DateTime date { get; set; }
}