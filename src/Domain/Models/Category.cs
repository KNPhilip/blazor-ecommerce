using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public sealed class Category : DbEntity
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public bool Visible { get; set; } = true;
    [NotMapped]
    public bool IsNew { get; set; }
    [NotMapped]
    public bool Editing { get; set; }
}
