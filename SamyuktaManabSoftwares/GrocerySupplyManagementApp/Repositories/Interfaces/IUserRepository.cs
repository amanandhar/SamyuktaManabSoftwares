using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(string username, string type);
        User GetUser(long id);
        User GetUser(string username);
        bool IsUserExist(string username, string password);

        User AddUser(User user);

        User UpdateUser(long id, User user);
        User UpdateUser(string username, User user);
        bool UpdatePassword(string username, string password);

        bool DeleteUser(long id);
        bool DeleteUser(string username);
    }
}
