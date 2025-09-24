using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public sealed class DbUser : IdentityUser
{
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime BirthDate { get; set; }
    public bool IsSoftDeleted { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName { get => $"{FirstName} {LastName}"; }
    public string? NickName { get; set; }
    public Address? Address { get; set; }
    public List<Product> PublishedProducts { get; set; } = [];
}
