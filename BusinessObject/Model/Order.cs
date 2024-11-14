using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public int UserOrderID { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOrder { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual User? UserOrder { get; set; }

        public static implicit operator int(Order v)
        {
            throw new NotImplementedException();
        }
    }
}
