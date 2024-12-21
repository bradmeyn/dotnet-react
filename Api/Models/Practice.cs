namespace Api.Models;

public class Practice
{
    public Practice()
    {
        Users = new List<ApplicationUser>();
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string BusinessNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    
    public Guid OwnerId { get; set; }
    public ApplicationUser Owner { get; set; }
    public ICollection<ApplicationUser> Users { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}