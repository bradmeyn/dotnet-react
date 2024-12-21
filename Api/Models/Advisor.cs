namespace Api.Models;

public class Advisor : ApplicationUser
{
    public string LicenseNumber { get; set; } = string.Empty;
    public string Certifications { get; set; } = string.Empty;
    public ICollection<Client> Clients { get; set; } = new List<Client>();
}
