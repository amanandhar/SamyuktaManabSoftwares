using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        bool IsUserExist(string username, string password);

        User AddUser(User user);

        User UpdateUser(long id, User user);
        User UpdateUser(string username, User user);
        bool UpdatePassword(string username, string password);

        bool DeleteUser(long id);
        bool DeleteUser(string username);
    }
}
