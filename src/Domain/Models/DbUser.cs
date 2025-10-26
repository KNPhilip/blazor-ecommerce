using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public sealed class DbUser : IdentityUser
{
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime? BirthDate { get; set; }
    public bool IsSoftDeleted { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName { get => $"{FirstName} {LastName}"; }
    public string? NickName { get; set; }
    public Address? Address { get; set; }
    public List<Product> Favorites { get; set; } = [];
    public List<Product> PublishedProducts { get; set; } = [];
    [NotMapped]
    public bool IsNew { get; set; }
    [NotMapped]
    public bool Editing { get; set; }

    public bool HasNoName()
    {
        return string.IsNullOrWhiteSpace(FirstName) 
            && string.IsNullOrWhiteSpace(LastName);
    }

    public bool HasNoNickname()
    {
        return string.IsNullOrWhiteSpace(NickName);
    }
}
