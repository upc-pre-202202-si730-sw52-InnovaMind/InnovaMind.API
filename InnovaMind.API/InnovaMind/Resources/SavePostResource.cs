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
    [Required]
    public string Amount { get; set; }

    [Required] 
    public string Category { get; set; }

    [Required]
    public string location { get; set; }
    
    [Required]
    public int Time { get; set; }
    [Required]
    public string ImagenURL { get; set; }
}