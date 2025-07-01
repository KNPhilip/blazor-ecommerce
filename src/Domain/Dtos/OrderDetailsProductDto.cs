using Domain.Models;

namespace Domain.Dtos;

public sealed class OrderDetailsProductDto
{
    public int ProductId { get; set; }
    public required string Title { get; set; }
    public required string ProductType { get; set; }
    public required string ImageUrl { get; set; }
    public List<Image> Images { get; set; } = [];
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
