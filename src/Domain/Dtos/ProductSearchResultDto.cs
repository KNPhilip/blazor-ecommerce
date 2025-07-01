using Domain.Models;

namespace Domain.Dtos;

public sealed class ProductSearchResultDto
{
    public List<Product> Products { get; set; } = [];
    public int Pages { get; set; }
    public int CurrentPage { get; set; }
}
