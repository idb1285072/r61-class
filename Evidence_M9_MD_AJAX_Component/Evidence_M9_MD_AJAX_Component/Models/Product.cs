using System;
using System.Collections.Generic;

namespace Evidence_M9_MD_AJAX_Component.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } 
}
