using InnovaMind.API.Security.Domain.Models;
using System.Text.Json.Serialization;

namespace InnovaMind.API.InnovaMind.Domain.Models;
public class Address
{
    public int Id { get; set; }
    public string NameAddress { get; set; }

    //Relationships
    public int UserId { get; set; }
    public User User { get; set; }

}
