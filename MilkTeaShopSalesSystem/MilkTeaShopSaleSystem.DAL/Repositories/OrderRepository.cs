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
        public List<Order> getOrderToManager()
        {
            _context = new();
            return _context.Orders.Include("Staff").ToList();
        }

        public void PlaceOrder(Order order, List<OrderDetail> orderDetails)
        {
            _context = new();
            try
            {
                if (order == null) throw new ArgumentNullException(nameof(order));
                if (orderDetails == null || !orderDetails.Any())
                    throw new ArgumentException("Order details cannot be null or empty.");

                // Save the order
                _context.Orders.Add(order);
                _context.SaveChanges(); // Generate OrderId

                // Validate OrderId existence
                if (!_context.Orders.Any(o => o.OrderId == order.OrderId))
                    throw new InvalidOperationException($"OrderId {order.OrderId} does not exist in Orders table.");

                // Validate and save order details
                foreach (var detail in orderDetails)
                {
                    if (detail.DrinkId <= 0 || string.IsNullOrWhiteSpace(detail.Size))
                        throw new InvalidOperationException($"Invalid DrinkId ({detail.DrinkId}) or Size ({detail.Size}) in OrderDetail.");

                    // Validate Price existence
                    detail.Price = _context.Prices.FirstOrDefault(p => p.DrinkId == detail.DrinkId && p.Size == detail.Size);
                    if (detail.Price == null)
                        throw new InvalidOperationException($"Price not found for DrinkId {detail.DrinkId} and Size {detail.Size}.");

                    detail.OrderId = order.OrderId; // Assign OrderId
                    _context.OrderDetails.Add(detail); // Add to context
                }

                // Save changes
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database Update Error: {dbEx.InnerException?.Message ?? dbEx.Message}");
                Console.WriteLine($"Stack Trace: {dbEx.StackTrace}");
                throw new Exception($"Failed to save order and details. Inner Exception: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

    }
}
