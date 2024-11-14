using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleRepository : IRoleRepository
    {
        public void AddRole(Role role)
        {
            RoleDAO.Instance.AddRole(role);
        }

        public void DeleteRole(int id)
        {
            RoleDAO.Instance.DeleteRole(id);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return RoleDAO.Instance.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return RoleDAO.Instance.GetRoleById(id);
        }

        public void UpdateRole(Role role)
        {
            RoleDAO.Instance.UpdateRole(role);
        }
    }
}
