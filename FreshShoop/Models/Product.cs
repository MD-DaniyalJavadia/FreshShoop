using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreshShoop.Models;

public partial class Product
{
    public string Id { get; set; } = null!;
    [Required]

    public string? Name { get; set; }
    [DisplayName("Product Image 1")]
    public string? Image1 { get; set; }
    [DisplayName("Product Image 2")]
    public string? Image { get; set; }
    [DisplayName("Product Image 3")]

    public string? Image3 { get; set; }
    [Required]
    [DisplayName("Description")]


    public string Description { get; set; } = null!;
    [Required]
    [DisplayName("Qunatity")]

    public int Qunatity { get; set; }
    [Required]
    [DisplayName("Unit Price")]
    public double UnitPrice { get; set; }
    [Required]
    [DisplayName("Sale Price")]
    public double SalePrice { get; set; }
    [Required]
    [DisplayName("Category Name")]
    public string CategoryId { get; set; } = null!;
    [DisplayName("Status")]
    public string Satatus { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
