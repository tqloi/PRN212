using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(Category category)
        {
            CategoryDAO.Instance.AddCategory(category);
        }

        public void DeleteCategory(int id)
        {
            CategoryDAO.Instance.DeleteCategory(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return CategoryDAO.Instance.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return CategoryDAO.Instance.GetCategoryById(id);
        }

        public void UpdateCategory(Category category)
        {
            CategoryDAO.Instance.UpdateCategory(category);
        }
    }
}
