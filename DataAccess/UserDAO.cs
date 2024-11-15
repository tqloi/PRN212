using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO : SingletonBase<UserDAO>
    {
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
            /*return _context.Users.Include(p => p.Role).ToList();*/
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return null;

            return user;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            var existing = _context.Users.Find(user.UserID);
            if (existing == null) return;
            _context.Entry(existing).CurrentValues.SetValues(user);
            _context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void DeleteUserBasedOnStatus(int id)
        {
            var user = _context.Users.Find(id);
            if(user != null)
            {
                user.Status = !user.Status;
                _context.SaveChanges();
            }
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            return _context.Users.SingleOrDefault(p => p.UserName.Equals(userName) && p.Password.Equals(password));
        }
    }
}
