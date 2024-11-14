using BusinessObject.Model;
using DataAccess;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CareScheduleService : ICareScheduleService
    {
        private readonly ICareScheduleRepository _careScheduleRepository;
        public CareScheduleService()
        {
            _careScheduleRepository = new CareScheduleRepository();
        }
        public IEnumerable<CareSchedule> GetAllCareSchedules()
        {
            return _careScheduleRepository.GetAllCareSchedules();
        }
        public CareSchedule GetCareScheduleById(int careScheduleID)
        {
            return _careScheduleRepository.GetCareScheduleById(careScheduleID);
        }
        public IEnumerable<CareSchedule> GetCareScheduleByPlantID(int plantID)
        {
            return _careScheduleRepository.GetCareScheduleByPlantID(plantID);
        }
        public IEnumerable<CareSchedule> GetCareScheduleByUserID(int userID)
        {
            return _careScheduleRepository.GetCareScheduleByUserID(userID);
        }
        public IEnumerable<CareSchedule> GetCareScheduleByCareServiceID(int careServiceID)
        {
            return _careScheduleRepository.GetCareScheduleByCareServiceID(careServiceID);
        }
        public void AddCareSchedule(CareSchedule careSchedule)
        {
            _careScheduleRepository.AddCareSchedule(careSchedule);
        }
        public void DeleteCareSchedule(int careScheduleID)
        {
            _careScheduleRepository.DeleteCareSchedule(careScheduleID);
        }
        public void UpdateCareSchedule(CareSchedule careSchedule)
        {
            _careScheduleRepository.UpdateCareSchedule(careSchedule);
        }
    }
}
