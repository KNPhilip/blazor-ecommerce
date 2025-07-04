using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public sealed class ProductType : DbEntity
{
    public string Name { get; set; } = string.Empty;
    [NotMapped]
    public bool IsNew { get; set; }
    [NotMapped]
    public bool Editing { get; set; }
}
