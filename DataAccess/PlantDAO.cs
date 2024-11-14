using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PlantDAO : SingletonBase<PlantDAO>
    {
        public IEnumerable<Plant> GetAllPlants()
        {
            return _context.Plants.ToList();
            /*return _context.Plants.Include(p => p.Category).ToList();*/
        }

        public Plant GetPlantById(int id)
        {
            var plant
                = _context.Plants.Find(id);
            if (plant
                == null) return null;

            return plant
                ;
        }
        public void AddPlant(Plant plant
            )
        {
            _context.Plants.Add(plant
                );
            _context.SaveChanges();
        }
        public void UpdatePlant(Plant plant
            )
        {
            var existing = _context.Plants.Find(plant
                .PlantID);
            if (existing == null) return;
            _context.Entry(existing).CurrentValues.SetValues(plant
                );
            _context.SaveChanges();
        }
        public void DeletePlant(int id)
        {
            var plant
                = _context.Plants.Find(id);
            if (plant
                != null)
            {
                _context.Plants.Remove(plant
                    );
                _context.SaveChanges();
            }
        }
    }
}
