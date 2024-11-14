using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CareServiceDAO : SingletonBase<CareServiceDAO>
    {
        public IEnumerable<CareService> GetAllCareServices()
        {
            return _context.CareServices.ToList();
        }

        public CareService GetCareServiceById(int id)
        {
            var careService = _context.CareServices.Find(id);
            if (careService == null) return null;

            return careService;
        }
        public void AddCareService(CareService careService)
        {
            _context.CareServices.Add(careService);
            _context.SaveChanges();
        }
        public void UpdateCareService(CareService careService)
        {
            var existing = _context.CareServices.Find(careService.CareServiceID);
            if (existing == null) return;
            _context.Entry(existing).CurrentValues.SetValues(careService);
            _context.SaveChanges();
        }
        public void DeleteCareService(int id)
        {
            var careService = _context.CareServices.Find(id);
            if (careService != null)
            {
                _context.CareServices.Remove(careService);
                _context.SaveChanges();
            }
        }
    }
}
