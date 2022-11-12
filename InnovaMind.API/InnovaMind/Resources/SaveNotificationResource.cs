using InnovaMind.API.Security.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;

public class SaveNotificationResource
{
    [Required]
    public int UserId { get; set; }
    [MaxLength(250)]
    public string Content { get; set; }
    
}