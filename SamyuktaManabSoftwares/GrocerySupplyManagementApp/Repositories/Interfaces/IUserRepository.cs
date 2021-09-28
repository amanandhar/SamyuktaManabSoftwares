using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        bool IsUserExist(string username, string password);

        User AddUser(User user);

        User UpdateUser(long id, User user);
        User UpdateUser(string username, User user);

        bool DeleteUser(long id);
        bool DeleteUser(string username);
    }
}
