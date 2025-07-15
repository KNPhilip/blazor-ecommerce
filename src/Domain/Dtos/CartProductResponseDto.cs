using Domain.Models;

namespace Domain.Dtos;

public sealed class CartProductResponseDto
{
    public int ProductId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ProductTypeId { get; set; }
    public string ProductType { get; set; } = string.Empty;
    public List<Image> Images { get; set; } = [];
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
