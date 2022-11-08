using System.ComponentModel.DataAnnotations;
namespace InnovaMind.API.Security.Domain.Services.Communication;
public class RegisterRequest
{
    [Required]
    public string FistName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}