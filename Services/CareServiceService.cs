using BusinessObject.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CareServiceService : ICareServiceService
    {
        private readonly ICareServiceRepository _careServiceRepository;
        public CareServiceService()
        {
            _careServiceRepository = new CareServiceRepository();
        }
        public void AddCareService(CareService careService)
        {
            _careServiceRepository.AddCareService(careService);
        }
        public void DeleteCareService(int id)
        {
            _careServiceRepository.DeleteCareService(id);
        }
        public IEnumerable<CareService> GetAllCareServices()
        {
            return _careServiceRepository.GetAllCareServices();
        }
        public CareService GetCareServiceById(int id)
        {
            return _careServiceRepository.GetCareServiceById(id);
        }
        public void UpdateCareService(CareService careService)
        {
            _careServiceRepository.UpdateCareService(careService);
        }
    }
}
