using System;
using System.Collections.Generic;

namespace MilkTeaShopSaleSystem.DAL.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? StaffId { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? OrderStatus { get; set; }

    public virtual User? Staff { get; set; }
}
