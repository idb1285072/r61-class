using System;
using System.Collections.Generic;

namespace Evidence_M9_MD_AJAX_Component.Models;

public partial class Order
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = null!;

    public string? CustomerName { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? Picture { get; set; }

    public bool? IsDelivered { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }=new List<OrderDetail>();
}
