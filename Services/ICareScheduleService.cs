using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICareScheduleService
    {
        IEnumerable<CareSchedule> GetAllCareSchedules();
        IEnumerable<CareSchedule> GetCareScheduleByUserID(int userID);
        IEnumerable<CareSchedule> GetCareScheduleByPlantID(int plantID);
        IEnumerable<CareSchedule> GetCareScheduleByCareServiceID(int careServiceID);
        CareSchedule GetCareScheduleById(int careScheduleID);
        void AddCareSchedule(CareSchedule orderDetail);
        void UpdateCareSchedule(CareSchedule orderDetail);
        void DeleteCareSchedule(int careScheduleID);
    }
}
