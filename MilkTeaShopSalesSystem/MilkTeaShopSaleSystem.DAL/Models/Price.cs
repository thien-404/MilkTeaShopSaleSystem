using System;
using System.Collections.Generic;

namespace MilkTeaShopSaleSystem.DAL.Models;

public partial class Price
{
    public int DrinkId { get; set; }

    public string Size { get; set; } = null!;

    public decimal? Price1 { get; set; }

    public int? PriceStatus { get; set; }
    public string PriceSatusText
    {
        get
        {
            return PriceStatus == 1 ? "Inactive" : "Active";
        }
    }

    public virtual Drink Drink { get; set; } = null!;
}
