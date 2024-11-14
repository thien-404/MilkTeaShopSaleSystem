using Microsoft.EntityFrameworkCore;
using MilkTeaShopSaleSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.DAL.Repositories
{
    public class OrderRepository
    {
        private MilkTeaShopSaleDbContext _context;

        public List<Order> getOrderToStaff(int staffId)
        {
            _context = new();
            return _context.Orders.Include("Staff").Where(o => o.StaffId == staffId).ToList();
        }
    }
}
