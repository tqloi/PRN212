using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailDAO.Instance.AddOrderDetail(orderDetail);
        }

        public void DeleteOrderDetail(int orderID, int plantID)
        {
            OrderDetailDAO.Instance.DeleteOrderDetail(orderID, plantID);
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return OrderDetailDAO.Instance.GetAllOrderDetails();
        }

        public OrderDetail GetOrderDetailById(int orderID, int plantID)
        {
            return OrderDetailDAO.Instance.GetOrderDetailById(orderID, plantID);
        }

        public IEnumerable<OrderDetail> GetOrderDetailByPlantID(int plantID)
        {
            return OrderDetailDAO.Instance.GetOrderDetailByPlantID(plantID);
        }

        public IEnumerable<OrderDetail> GetOrderDetailByOrderID(int orderID)
        {
            return OrderDetailDAO.Instance.GetOrderDetailByOrderID(orderID);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
        }
    }
}
