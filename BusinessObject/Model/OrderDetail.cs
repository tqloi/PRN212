using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    [PrimaryKey(nameof(OrderID), nameof(PlantID))]
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int PlantID { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Plant? Plant { get; set; }
    }
}
