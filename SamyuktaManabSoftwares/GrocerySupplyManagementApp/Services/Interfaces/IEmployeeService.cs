using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(long id);
        Employee GetEmployee(string employeeId);
        string GetNewEmployeeId();
        IEnumerable<Employee> GetDeliveryPersons();

        Employee AddEmployee(Employee employee);

        Employee UpdateEmployee(string employeeId, Employee employee);

        bool DeleteEmployee(string employeeId);
    }
}
