using System;
using System.Collections.Generic;

namespace FreshShoop.Models;

public partial class Order
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string OrderCreationDate { get; set; } = null!;

    public int Items { get; set; }

    public double TotalPrice { get; set; }

    public string Discount { get; set; } = null!;

    public double Subtotal { get; set; }

    public string Status { get; set; } = null!;
}
