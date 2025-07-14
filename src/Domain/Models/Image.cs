using Domain.Enums;

namespace Domain.Models;

public sealed class Image
{
    public int Id { get; set; }
    public string? Data { get; set; }
    public ImageType? Type { get; set; }
    public int ProductId { get; set; }
}
