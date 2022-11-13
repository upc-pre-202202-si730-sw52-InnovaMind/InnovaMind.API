namespace InnovaMind.API.InnovaMind.Domain.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string RUC { get; set; }
    public string Owner { get; set; }
    public Recruiter Recruiter { get; set; }
}