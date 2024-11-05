using System;
using System.Collections.Generic;

namespace MilkTeaShopSaleSystem.DAL.Models;

public partial class Drink
{
    public int DrinkId { get; set; }

    public string? DrinkName { get; set; }

    public string? Description { get; set; }

    public int? DrinkStatus { get; set; }

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
}
