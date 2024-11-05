using System;
using System.Collections.Generic;

namespace MilkTeaShopSaleSystem.DAL.Models;

public partial class OrderDetail
{
    public int? OrderId { get; set; }

    public int? DrinkId { get; set; }

    public int? Quantity { get; set; }

    public virtual Drink? Drink { get; set; }

    public virtual Order? Order { get; set; }
}
