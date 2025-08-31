using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public sealed class Image
{
    public int Id { get; set; }
    public string? Data { get; set; }
    public ImageType? Type { get; set; }
    public int ProductId { get; set; }
    [NotMapped]
    public bool IsNew { get; set; }
}
