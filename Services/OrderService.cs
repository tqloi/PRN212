using BusinessObject.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }
        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public IEnumerable<Order> GetOrderByUser(int userOrderID)
        {
            return _orderRepository.GetOrderByUser(userOrderID);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }
        public IEnumerable<Order> SearchByKeyword(string keyword)
        {
            return _orderRepository.SearchByKeyword(keyword);
        }
    }
}
