using System;
using System.Collections.Generic;

namespace FreshShoop.Models;

public partial class Cart
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
