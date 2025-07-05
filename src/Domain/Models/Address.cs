using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public sealed class Address : DbEntity
{
    public string? UserId { get; set; }
    [Required, StringLength(20)]
    public string? FirstName { get; set; }
    [Required, StringLength(20)]
    public string? LastName { get; set; }
    public string? FullName { get => $"{FirstName} {LastName}"; }
    [Required, StringLength(50)]
    public string? Street { get; set; }
    [Required, StringLength(50)]
    public string? City { get; set; }
    public string? State { get; set; }
    [Required, StringLength(10)]
    public string? Zip { get; set; }
    [Required, StringLength(30)]
    public string? Country { get; set; }
}
