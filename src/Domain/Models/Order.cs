namespace Domain.Models;

public sealed class Order
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal TotalPrice { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
}
