using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class CareSchedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CareScheduleID { get; set; }
        public int PlantID { get; set; }
        public int UserID { get; set; }
        public bool Status { get; set; } = false;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? FinishTime { get; set; } = null;
        public int CareServiceID { get; set; }
        public virtual CareService? CareService { get; set; }
        public virtual Plant? Plant { get; set; }
        public virtual User? User { get; set; }
    }
}
