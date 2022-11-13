using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Security.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;

public class SaveCompanyResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string RUC { get; set; }
    public string Owner { get; set; }
    public Recruiter Recruiter { get; set; }
}