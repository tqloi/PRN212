using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PlantRepository : IPlantRepository
    {
        public void AddPlant(Plant plant)
        {
            PlantDAO.Instance.AddPlant(plant);
        }

        public void DeletePlant(int id)
        {
            PlantDAO.Instance.DeletePlant(id);
        }

        public IEnumerable<Plant> GetAllPlants()
        {
            return PlantDAO.Instance.GetAllPlants();
        }

        public Plant GetPlantById(int id)
        {
            return PlantDAO.Instance.GetPlantById(id);
        }

        public void UpdatePlant(Plant plant)
        {
            PlantDAO.Instance.UpdatePlant(plant);
        }
    }
}
