using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(User user)
        {
            UserDAO.Instance.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            UserDAO.Instance.DeleteUser(id);
        }

        public void DeleteUserBasedOnStatus(int id)
        {
            UserDAO.Instance.DeleteUserBasedOnStatus(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return UserDAO.Instance.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return UserDAO.Instance.GetUserById(id);
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            return UserDAO.Instance.GetUserByUserNameAndPassword(userName, password);
        }

        public void UpdateUser(User user)
        {
            UserDAO.Instance.UpdateUser(user);
        }
    }
}
