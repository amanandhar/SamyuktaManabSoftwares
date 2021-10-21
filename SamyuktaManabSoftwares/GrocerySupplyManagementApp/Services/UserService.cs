using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers(string username, string type)
        {
            return _userRepository.GetUsers(username, type);
        }

        public User GetUser(long id)
        {
            return _userRepository.GetUser(id);
        }

        public User GetUser(string username)
        {
            return _userRepository.GetUser(username);
        }

        public bool IsUserExist(string username)
        {
            return _userRepository.IsUserExist(username);
        }

        public bool IsUserExist(string username, string password)
        {
            return _userRepository.IsUserExist(username, password);
        }

        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public User UpdateUser(string username, User user)
        {
            return _userRepository.UpdateUser(username, user);
        }

        public bool DeleteUser(string username)
        {
            return _userRepository.DeleteUser(username);
        }
    }
}
