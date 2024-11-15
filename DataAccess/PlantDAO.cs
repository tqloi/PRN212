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
            //return _context.Plants.ToList();
            return _context.Plants.Include(p => p.Category).ToList();
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
        public IEnumerable<Plant> SearchByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return Enumerable.Empty<Plant>(); // Nếu không có từ khóa, trả về danh sách rỗng
            }

            var plants = _context.Plants
                .Include(p => p.Category)  // Bao gồm thông tin của Category
                .Where(p => EF.Functions.Like(p.PlantName, "%" + keyword + "%") ||  // Tìm kiếm trong tên cây
                            EF.Functions.Like(p.Category.CategoryName, "%" + keyword + "%"))  // Tìm kiếm trong tên danh mục
                .ToList();

            return plants;
        }
        public IEnumerable<Plant> FilterByPrice(decimal minPrice, decimal maxPrice)
        {
            // Kiểm tra nếu giá trị minPrice và maxPrice hợp lệ
            if (minPrice < 0 || maxPrice < 0)
            {
                throw new ArgumentException("Giá không thể là số âm.");
            }

            // Nếu giá thấp hơn lớn hơn giá cao, đổi lại
            if (minPrice > maxPrice)
            {
                decimal temp = minPrice;
                minPrice = maxPrice;
                maxPrice = temp;
            }

            var plants = _context.Plants
                .Include(p => p.Category)  // Bao gồm thông tin của Category
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)  // Lọc theo giá
                .ToList();

            return plants;
        }

    }
}
