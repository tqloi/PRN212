using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO : SingletonBase<OrderDetailDAO>
    {
        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails.ToList();
            /*return _context.OrderDetails.Include(p => p.Plants).Include(p => p.Orders).ToList();*/
        }

        public IEnumerable<OrderDetail> GetOrderDetailByOrderID(int orderID)
        {
            /*var orderDetail = _context.OrderDetails.Where(p => p.OrderID == orderID).ToList();*/
            var orderDetail = _context.OrderDetails.Where(p => p.OrderID == orderID).Include(p => p.Plant).Include(p => p.Order).ToList();
            if (orderDetail == null) return null;

            return orderDetail;
        }

        public IEnumerable<OrderDetail> GetOrderDetailByPlantID(int plantID)
        {
            var orderDetail = _context.OrderDetails.Where(p =>p.PlantID == plantID).Include(p => p.Plant).ToList();
            /*var orderDetail = _context.OrderDetails.Where(p => p.PlantID == plantID).Include(p => p.Plants).Include(p => p.Orders).ToList();*/
            if (orderDetail == null) return null;

            return orderDetail;
        }

        public OrderDetail GetOrderDetailById(int orderID, int plantID)
        {
            var orderDetail = _context.OrderDetails.SingleOrDefault(p => p.OrderID == orderID && p.PlantID == plantID);
            if (orderDetail == null) return null;

            return orderDetail;
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            var existing = _context.OrderDetails.Find(orderDetail.OrderID);
            if (existing == null) return;
            _context.Entry(existing).CurrentValues.SetValues(orderDetail);
            _context.SaveChanges();
        }
        public void DeleteOrderDetail(int orderID, int plantID)
        {
            var orderDetail = _context.OrderDetails.SingleOrDefault(p => p.OrderID == orderID && p.PlantID == plantID);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                _context.SaveChanges();
            }
        }
    }
}
