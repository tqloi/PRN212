using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CareScheduleRepository : ICareScheduleRepository
    {
        public IEnumerable<CareSchedule> GetAllCareSchedules()
        {
            return CareScheduleDAO.Instance.GetAllCareSchedules();
        }
        public CareSchedule GetCareScheduleById(int careScheduleID)
        {
            return CareScheduleDAO.Instance.GetCareScheduleById(careScheduleID);
        }
        public IEnumerable<CareSchedule> GetCareScheduleByPlantID(int plantID)
        {
            return CareScheduleDAO.Instance.GetCareScheduleByPlantID(plantID);
        }
        public IEnumerable<CareSchedule> GetCareScheduleByUserID(int userID)
        {
            return CareScheduleDAO.Instance.GetCareScheduleByUserID(userID);
        }
        public IEnumerable<CareSchedule> GetCareScheduleByCareServiceID(int careServiceID)
        {
            return CareScheduleDAO.Instance.GetCareScheduleByCareServiceID(careServiceID);
        }
        public void AddCareSchedule(CareSchedule careSchedule)
        {
            CareScheduleDAO.Instance.AddCareSchedule(careSchedule);
        }
        public void DeleteCareSchedule(int careScheduleID)
        {
            CareScheduleDAO.Instance.DeleteCareSchedule(careScheduleID);
        }
        public void UpdateCareSchedule(CareSchedule careSchedule)
        {
            CareScheduleDAO.Instance.UpdateCareSchedule(careSchedule);
        }
        public void ChangeState(int careSchedule)
        {
            CareScheduleDAO.Instance.ChangeState(careSchedule);
        }
        public IEnumerable<CareSchedule> SearchByKeyword(string keyword)
        {
            return CareScheduleDAO.Instance.SearchByKeyword(keyword);
        }
    }
}
