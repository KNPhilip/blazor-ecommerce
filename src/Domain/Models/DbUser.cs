using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public sealed class DbUser : IdentityUser
{
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public bool IsSoftDeleted { get; set; }
    public Address? Address { get; set; }
}
