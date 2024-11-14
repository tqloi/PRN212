using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CareServiceRepository : ICareServiceRepository
    {
        public void AddCareService(CareService category)
        {
            CareServiceDAO.Instance.AddCareService(category);
        }

        public void DeleteCareService(int id)
        {
            CareServiceDAO.Instance.DeleteCareService(id);
        }

        public IEnumerable<CareService> GetAllCareServices()
        {
            return CareServiceDAO.Instance.GetAllCareServices();
        }

        public CareService GetCareServiceById(int id)
        {
            return CareServiceDAO.Instance.GetCareServiceById(id);
        }

        public void UpdateCareService(CareService category)
        {
            CareServiceDAO.Instance.UpdateCareService(category);
        }
    }
}
