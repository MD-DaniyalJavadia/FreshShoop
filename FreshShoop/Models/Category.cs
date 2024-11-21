using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreshShoop.Models;

public partial class Category
{

    public string Id { get; set; } = null!;
    [Required]
    [DisplayName("Category Name")]
    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
