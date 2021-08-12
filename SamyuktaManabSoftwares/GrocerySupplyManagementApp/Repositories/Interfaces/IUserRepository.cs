using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);

        User AddUser(User user);

        User UpdateUser(long id, User user);

        bool DeleteUser(long id);
    }
}
