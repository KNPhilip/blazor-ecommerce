using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public sealed class Product : DbEntity
{
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<Image> Images { get; set; } = [];
    public bool Featured { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    public List<ProductVariant> Variants { get; set; } = [];
    public bool Visible { get; set; } = true;
    [NotMapped]
    public bool IsNew { get; set; }
    [NotMapped]
    public bool Editing { get; set; }
}
