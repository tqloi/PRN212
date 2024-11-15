using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CareScheduleDAO : SingletonBase<CareScheduleDAO>
    {
        public IEnumerable<CareSchedule> GetAllCareSchedules()
        {
            return _context.CareSchedules
                .Include(p => p.User)
                .Include(p => p.Plant)
                .Include(p => p.CareService).ToList();
            /*return _context.CareSchedules.Include(p => p.Plants).Include(p => p.Orders).ToList();*/
        }

        public IEnumerable<CareSchedule> GetCareScheduleByUserID(int userID)
        {
            /*var careSchedule = _context.CareSchedules.Where(p => p.UserID == userID).ToList();*/
            var careSchedule = _context.CareSchedules.Where(p => p.UserID == userID).Include(p => p.Plant).Include(u => u.CareService).Include(p => p.User).ToList();
            if (careSchedule == null) return null;

            return careSchedule;
        }

        public IEnumerable<CareSchedule> GetCareScheduleByPlantID(int plantID)
        {
            var careSchedule = _context.CareSchedules.Where(p => p.PlantID == plantID).ToList();
            /*var careSchedule = _context.CareSchedules.Where(p => p.PlantID == plantID).Include(p => p.Plants).Include(p => p.Orders).ToList();*/
            if (careSchedule == null) return null;
            return careSchedule;
        }

        public IEnumerable<CareSchedule> GetCareScheduleByCareServiceID(int careServiceID)
        {
            var careSchedule = _context.CareSchedules.Where(p => p.CareServiceID == careServiceID).ToList();
            /*var careSchedule = _context.CareSchedules.Where(p => p.PlantID == plantID).Include(p => p.Plants).Include(p => p.Orders).ToList();*/
            if (careSchedule == null) return null;
            return careSchedule;
        }

        public CareSchedule GetCareScheduleById(int careScheduleID)
        {
            var careSchedule = _context.CareSchedules.SingleOrDefault(p => p.CareScheduleID == careScheduleID);
            if (careSchedule == null) return null;

            return careSchedule;
        }
        public void AddCareSchedule(CareSchedule careSchedule)
        {
            _context.CareSchedules.Add(careSchedule);
            _context.SaveChanges();
        }
        public void UpdateCareSchedule(CareSchedule careSchedule)
        {
            var existing = _context.CareSchedules.Find(careSchedule.UserID);
            if (existing == null) return;
            _context.Entry(existing).CurrentValues.SetValues(careSchedule);
            _context.SaveChanges();
        }
        public void DeleteCareSchedule(int careScheduleID)
        {
            var careSchedule = _context.CareSchedules.SingleOrDefault(p => p.CareScheduleID == careScheduleID);
            if (careSchedule != null)
            {
                _context.CareSchedules.Remove(careSchedule);
                _context.SaveChanges();
            }
        }
        public void ChangeState(int careScheduleID)
        {
            var careSchedule = _context.CareSchedules.SingleOrDefault(p => p.CareScheduleID == careScheduleID);
            if (careSchedule != null)
            {
                careSchedule.FinishTime = careSchedule.FinishTime == null ? DateTime.Now : (DateTime?)null;
                careSchedule.Status = !careSchedule.Status;
                _context.SaveChanges();
            }
        }
        public IEnumerable<CareSchedule> SearchByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return Enumerable.Empty<CareSchedule>();
            }

            // Tạo một đối tượng DateTime để so sánh với ngày tháng
            DateTime keywordDate;
            bool isDate = DateTime.TryParseExact(keyword, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out keywordDate);

            // Tìm kiếm trong CareService, Plant, User, và ngày tháng
            var careSchedules = _context.CareSchedules
                .Include(p => p.User)
                .Include(p => p.Plant)
                .Include(p => p.CareService)
                .Where(p => EF.Functions.Like(p.CareService.CareServiceName, $"%{keyword}%") ||
                            EF.Functions.Like(p.Plant.PlantName, $"%{keyword}%") ||
                            EF.Functions.Like(p.User.Fullname, $"%{keyword}%") ||
                            EF.Functions.Like(p.User.Email, $"%{keyword}%") ||
                            (isDate && p.StartDate.Date == keywordDate.Date) || // So sánh ngày bắt đầu
                            (p.FinishTime.HasValue && isDate && p.FinishTime.Value.Date == keywordDate.Date))  // So sánh ngày kết thúc
                .ToList();

            return careSchedules;
        }

    }
}