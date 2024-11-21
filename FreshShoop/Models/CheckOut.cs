using System;
using System.Collections.Generic;

namespace FreshShoop.Models;

public partial class CheckOut
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? Type { get; set; }

    public string? ShippigAddress { get; set; }

    public string? BillingAddress { get; set; }

    public string? ContactNo { get; set; }

    public string? Voucher { get; set; }
}
