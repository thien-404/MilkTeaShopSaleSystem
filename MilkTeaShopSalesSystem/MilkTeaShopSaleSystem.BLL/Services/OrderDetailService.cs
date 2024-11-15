using MilkTeaShopSaleSystem.DAL.Models;
using MilkTeaShopSaleSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaShopSaleSystem.BLL.Services
{
    public class OrderDetailService
    {
        private OrderDetailRepository _repo = new();

        public List<OrderDetail> getOrderDetail(int orderId)
        {
            return _repo.getAllOrderDetail(orderId);
        }
    }
}
