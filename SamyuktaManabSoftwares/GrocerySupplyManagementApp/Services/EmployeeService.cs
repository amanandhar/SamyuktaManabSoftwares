using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public Employee GetEmployee(long id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        public Employee GetEmployee(string employeeId)
        {
            return _employeeRepository.GetEmployee(employeeId);
        }

        public string GetNewEmployeeId()
        {
            string employeeId;
            var id = (_employeeRepository.GetLastEmployeeId() + 1).ToString();
            if (id.Length == 1)
            {
                employeeId = "000" + id;
            }
            else if (id.Length == 2)
            {
                employeeId = "00" + id;
            }
            else if (id.Length == 3)
            {
                employeeId = "0" + id;
            }
            else
            {
                employeeId = id;
            }

            return "E" + employeeId;
        }

        public IEnumerable<Employee> GetDeliveryPersons()
        {
            return _employeeRepository.GetDeliveryPersons();
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Counter = _employeeRepository.GetLastEmployeeId() + 1;
            return _employeeRepository.AddEmployee(employee);
        }

        public Employee UpdateEmployee(string employeeId, Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employeeId, employee);
        }

        public bool DeleteEmployee(string employeeId)
        {
            return _employeeRepository.DeleteEmployee(employeeId);
        }
    }
}
