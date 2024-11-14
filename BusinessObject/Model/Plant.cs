using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Plant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlantID { get; set; }
        [StringLength(100)]
        public string PlantName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public int CategoryID { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual ICollection<CareSchedule>? CareSchedules { get; set; }

    }
}
