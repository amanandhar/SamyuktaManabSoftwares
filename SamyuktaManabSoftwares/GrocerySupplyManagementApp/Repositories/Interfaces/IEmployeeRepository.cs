using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(long id);
        long GetLastEmployeeId();
        IEnumerable<Employee> GetDeliveryPersons();

        Employee AddEmployee(Employee employee);

        Employee UpdateEmployee(long id, Employee employee);
        Employee UpdateEmployee(string employeeId, Employee employee);

        bool DeleteEmployee(long id);
        bool DeleteEmployee(string employeeId);
    }
}
