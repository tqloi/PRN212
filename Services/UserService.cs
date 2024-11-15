using BusinessObject.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void DeleteUserBasedOnStatus(int id)
        {
            _userRepository.DeleteUserBasedOnStatus(id);
        }
        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            return _userRepository.GetUserByUserNameAndPassword(userName, password);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
        public IEnumerable<User> SearchByKeyword(string keyword)
        {
            return _userRepository.SearchByKeyword(keyword);
        }
    }
}
