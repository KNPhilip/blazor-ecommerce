using Domain.Models;

namespace Domain.Dtos;

public sealed class OrderOverviewDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public required string Product { get; set; }
    public List<Image> Images { get; set; } = [];
}
