using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICareServiceService
    {
        IEnumerable<CareService> GetAllCareServices();
        CareService GetCareServiceById(int id);
        void AddCareService(CareService careService);
        void UpdateCareService(CareService careService);
        void DeleteCareService(int id);
    }
}
