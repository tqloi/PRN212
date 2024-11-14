using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();
        IEnumerable<OrderDetail> GetOrderDetailByOrderID(int orderID);
        IEnumerable<OrderDetail> GetOrderDetailByPlantID(int laptopID);
        OrderDetail GetOrderDetailById(int orderID, int laptopID);
        void AddOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(int orderID, int laptopID);
    }
}
