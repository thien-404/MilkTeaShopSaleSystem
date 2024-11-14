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
        public void PlaceOrder(Order order, List<OrderDetail> orderDetails)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }

            if (orderDetails == null || !orderDetails.Any())
            {
                throw new ArgumentException("Order details cannot be null or empty.", nameof(orderDetails));
            }

            _repo.PlaceOrder(order, orderDetails);
        }

    }
}
