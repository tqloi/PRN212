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
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        public PlantService()
        {
            _plantRepository = new PlantRepository();
        }
        public void AddPlant(Plant plant)
        {
            _plantRepository.AddPlant(plant);
        }

        public void DeletePlant(int id)
        {
            _plantRepository.DeletePlant(id);
        }

        public IEnumerable<Plant> GetAllPlants()
        {
            return _plantRepository.GetAllPlants();
        }

        public Plant GetPlantById(int id)
        {
            return _plantRepository.GetPlantById(id);
        }

        public void UpdatePlant(Plant plant)
        {
            _plantRepository.UpdatePlant(plant);
        }
        public IEnumerable<Plant> SearchByKeyword(string keyword)
        {
            return _plantRepository.SearchByKeyword(keyword);
        }
        public IEnumerable<Plant> FilterByPrice(decimal minPrice, decimal maxPrice)
        {
            return _plantRepository.FilterByPrice(minPrice, maxPrice);
        }
    }
}
