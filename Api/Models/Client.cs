namespace Api.Models;

public class Client
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public bool IsActive { get; set; } = true;

    // Practice relationship
    public Guid PracticeId { get; set; }
    public Practice? Practice { get; set; }
    
    // Adviser relationship
    public Guid AdviserId { get; set; }
    public ApplicationUser? Adviser { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
