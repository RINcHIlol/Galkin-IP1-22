using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class Order
{
    public int Id { get; set; }

    public int ManufacturerId { get; set; }

    public int CustomerId { get; set; }

    public decimal Price { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<OrdersProduct> OrdersProducts { get; set; } = new List<OrdersProduct>();
}
