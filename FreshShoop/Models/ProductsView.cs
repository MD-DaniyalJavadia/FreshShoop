using System;
using System.Collections.Generic;

namespace FreshShoop.Models;

public partial class ProductsView
{
    public string Id { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Image1 { get; set; }

    public string Description { get; set; } = null!;

    public int Qunatity { get; set; }

    public double UnitPrice { get; set; }

    public double SalePrice { get; set; }

    public string? Name { get; set; }

    public string Satatus { get; set; } = null!;
}
