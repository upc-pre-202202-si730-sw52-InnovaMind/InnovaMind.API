using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.Security.Domain.Services.Communication;

public class UpdateRequest
{
    public string FistName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Phone { get; set; }
    
    public string Role { get; set; }

    public string Description { get; set; }

}