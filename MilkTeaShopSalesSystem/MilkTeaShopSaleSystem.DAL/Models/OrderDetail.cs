using System;
using System.Collections.Generic;

namespace MilkTeaShopSaleSystem.DAL.Models;

public partial class OrderDetail
{
    public int? OrderId { get; set; }

    public int? DrinkId { get; set; }

    public string? Size { get; set; }

    public int? Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Price? Price { get; set; }

    public decimal SubTotal => (decimal)((Price?.Price1 ?? 0) * Quantity);

}
