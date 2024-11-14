using BusinessObject.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService()
        {
            _orderDetailRepository = new OrderDetailRepository();
        }
        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailRepository.GetAllOrderDetails();
        }
        public OrderDetail GetOrderDetailById(int orderID, int plantID)
        {
            return _orderDetailRepository.GetOrderDetailById(orderID, plantID);
        }
        public IEnumerable<OrderDetail> GetOrderDetailByPlantID(int plantID)
        {
            return _orderDetailRepository.GetOrderDetailByPlantID(plantID);
        }
        public IEnumerable<OrderDetail> GetOrderDetailByOrderID(int orderID)
        {
            return _orderDetailRepository.GetOrderDetailByOrderID(orderID);
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.AddOrderDetail(orderDetail);
        }
        public void DeleteOrderDetail(int orderID, int plantID)
        {
            _orderDetailRepository.DeleteOrderDetail(orderID, plantID);
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }
    }
}
