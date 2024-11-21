using System;
using System.Collections.Generic;

namespace FreshShoop.Models;

public partial class OrderDetial
{
    public string Id { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public string UnitPrice { get; set; } = null!;

    public double Discount { get; set; }

    public double TotalAmount { get; set; }
}
