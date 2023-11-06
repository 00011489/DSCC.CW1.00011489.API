using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly EmployeeDb db;

        public EmployeeService(EmployeeDb db)
        {
            this.db = db;
        }

        public IEnumerable<Employee> AddEmployee(EmployeeDto employeeCreateDto)
        {
            if (employeeCreateDto == null) throw new ArgumentNullException();

            var employee = getEmployeeFromCreateDto(employeeCreateDto);

            db.Employees.Add(employee);
            db.SaveChanges();
            return getEmployeeList();
        }

        public Boolean DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);

            if(employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges ();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return getEmployeeList();
        }

        public Employee GetEmployeeById(int id)
        {
            return db.Employees.Find(id);
        }

        public IEnumerable<Employee> UpdateEmployee(Employee employee)
        {
            var emp = db.Employees.Find(employee.Id); 
            if(emp != null) { 
                emp.Age = employee.Age;
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Email = employee.Email;
                db.Update(emp);
                db.SaveChanges(true);
            }

            return getEmployeeList();
        }

        private List<Employee> getEmployeeList()
        {
            return db.Employees.OrderBy(e => e.Id).ToList();
        }

        private Employee getEmployeeFromCreateDto(EmployeeDto dto)
        {
            return new Employee
            {
                FirstName = dto.Firstname,
                LastName = dto.Lastname,
                Email = dto.Email,
                Age = dto.Age
            };
        }
    }
}
