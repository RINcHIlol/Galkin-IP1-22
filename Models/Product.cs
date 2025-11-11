using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Count { get; set; }

    public int ManufacturerId { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<OrdersProduct> OrdersProducts { get; set; } = new List<OrdersProduct>();
}
