using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> AddEmployee(EmployeeDto createDto);
        IEnumerable<Employee> UpdateEmployee(Employee employee);
        Boolean DeleteEmployee(int id);
    }
}
