using System;
using System.Collections.Generic;

namespace MilkTeaShopSaleSystem.DAL.Models;

public partial class Drink
{
    public int DrinkId { get; set; }

    public string? DrinkName { get; set; }

    public string? Description { get; set; }

    public int? DrinkStatus { get; set; }
    public string DrinkStatusText
    {
        get
        {
            return DrinkStatus == 1 ? "Inactive" : "Active";
        }
    }

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
}
