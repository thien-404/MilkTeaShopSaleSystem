using MilkTeaShopSaleSystem.DAL.Models;
using MilkTeaShopSaleSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.BLL.Services
{
    public class OrderService
    {
        private OrderRepository _repo = new();

        public List<Order> getOrderToStaff(int staffId)
        {
            return _repo.getOrderToStaff(staffId);
        }
    }
}
