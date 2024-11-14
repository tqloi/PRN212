using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class CareService
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CareServiceID { get; set; }
        public string CareServiceName { get; set; }
        public virtual ICollection<CareSchedule>? CareSchedules { get; set; }
    }
}
