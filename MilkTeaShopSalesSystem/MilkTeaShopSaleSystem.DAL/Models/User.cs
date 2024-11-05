using System;
using System.Collections.Generic;

namespace MilkTeaShopSaleSystem.DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? UserRole { get; set; }

    public int? UserStatus { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
