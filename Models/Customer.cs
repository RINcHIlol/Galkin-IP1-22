using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Inn { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool? Salesman { get; set; }

    public bool? Buyer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
