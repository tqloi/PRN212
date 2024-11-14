using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order order)
        {
            OrderDAO.Instance.AddOrder(order);
        }

        public void DeleteOrder(int id)
        {
            OrderDAO.Instance.DeleteOrder(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return OrderDAO.Instance.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return OrderDAO.Instance.GetOrderById(id);
        }

        public IEnumerable<Order> GetOrderByUser(int userOrderID)
        {
            return OrderDAO.Instance.GetOrderByUser(userOrderID);
        }

        public void UpdateOrder(Order order)
        {
            OrderDAO.Instance.UpdateOrder(order);
        }
    }
}
