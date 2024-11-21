using System;
using System.Collections.Generic;

namespace FreshShoop.Models;

public partial class Review
{
    public string? Id { get; set; }

    public string? Productid { get; set; }

    public string? Userid { get; set; }

    public string? Remarks { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public string? Status { get; set; }
}
