using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO : SingletonBase<OrderDAO>
    {
        public IEnumerable<Order> GetAllOrders()
        {
            /*return _context.Orders.ToList();*/
            return _context.Orders.Include(p => p.UserOrder).ToList();
        }

        public IEnumerable<Order> GetOrderByUser(int userOrderID)
        {
            /*var order = _context.Orders.Where(p => p.UserOrderID == userOrderID).ToList();*/
            var order = _context.Orders.Where(p => p.UserOrderID == userOrderID).Include(p => p.UserOrder).ToList();
            if (order == null) return null;

            return order;
        }

        public Order GetOrderById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return null;

            return order;
        }
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void UpdateOrder(Order order)
        {
            var existing = _context.Orders.Find(order.OrderID);
            if (existing == null) return;
            _context.Entry(existing).CurrentValues.SetValues(order);
            _context.SaveChanges();
        }
        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
