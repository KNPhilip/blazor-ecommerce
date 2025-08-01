﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public sealed class Order
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
}
