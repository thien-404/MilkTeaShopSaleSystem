using Microsoft.EntityFrameworkCore;
using MilkTeaShopSaleSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.DAL.Repositories
{
    public class OrderDetailRepository
    {
        private MilkTeaShopSaleDbContext _context;

        public List<OrderDetail> getAllOrderDetail(int orderId)
        {
            _context = new();
            return _context.OrderDetails.Include(od => od.Price).
                                            ThenInclude(p => p.Drink).
                                        Where(od => od.OrderId == orderId).
                                        ToList();
        }
    }
}
