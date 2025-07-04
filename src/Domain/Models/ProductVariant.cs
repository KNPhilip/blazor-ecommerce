using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public sealed class ProductVariant
{
    public Product? Product { get; set; }
    public int ProductId { get; set; }
    public ProductType? ProductType { get; set; }
    public int ProductTypeId { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal OriginalPrice { get; set; }
    public bool Visible { get; set; } = true;
    public bool IsSoftDeleted { get; set; }
    [NotMapped]
    public bool IsNew { get; set; }
}
