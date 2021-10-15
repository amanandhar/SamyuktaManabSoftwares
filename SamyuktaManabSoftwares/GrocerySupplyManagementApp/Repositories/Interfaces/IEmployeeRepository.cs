using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(long id);
        Employee GetEmployee(string employeeId);
        long GetLastEmployeeId();
        IEnumerable<Employee> GetDeliveryPersons();

        Employee AddEmployee(Employee employee);

        Employee UpdateEmployee(string employeeId, Employee employee);

        bool DeleteEmployee(string employeeId);
    }
}
