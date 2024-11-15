﻿using System;
using System.Collections.Generic;

namespace MilkTeaShopSaleSystem.DAL.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? StaffId { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? OrderStatus { get; set; }

    public virtual User? Staff { get; set; }

    public string OrderStatusDisplay
    {
        get
        {
            return OrderStatus switch
            {
                2 => "Completed",
                1 => "Pending",
                3 => "Cancelled",
                _ => "Unknown"
            };
        }
    }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
