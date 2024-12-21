using Microsoft.AspNetCore.Identity;

namespace Api.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    // Practice relationship
    public Guid PracticeId { get; set; }
    public Practice? Practice { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}