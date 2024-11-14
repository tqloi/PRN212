using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPlantRepository
    {
        IEnumerable<Plant> GetAllPlants();
        Plant GetPlantById(int id);
        void AddPlant(Plant plant);
        void UpdatePlant(Plant plant);
        void DeletePlant(int id);
    }
}
