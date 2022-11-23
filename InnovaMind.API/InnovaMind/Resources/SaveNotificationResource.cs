using InnovaMind.API.Security.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;

public class SaveNotificationResource
{
    [Required]
    public int EmitterId { get; set; }
    
    [Required]
    public string ReceiverId { get; set; }
    
    [Required]
    public string Content { get; set; }
}