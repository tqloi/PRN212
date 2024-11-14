using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleDAO : SingletonBase<RoleDAO>
    {
        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            var role = _context.Roles.Find(id);
            if (role == null) return null;

            return role;
        }
        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }
        public void UpdateRole(Role role)
        {
            var existing = _context.Roles.Find(role.RoleID);
            if (existing == null) return;
            _context.Entry(existing).CurrentValues.SetValues(role);
            _context.SaveChanges();
        }
        public void DeleteRole(int id)
        {
            var role = _context.Roles.Find(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}
