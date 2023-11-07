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

        //Add a new employee
        public IEnumerable<Employee> AddEmployee(EmployeeDto employeeCreateDto)
        {
            if (employeeCreateDto == null) throw new ArgumentNullException();

            var employee = getEmployeeFromCreateDto(employeeCreateDto);

            db.Employees.Add(employee);
            db.SaveChanges();
            return getEmployeeList();
        }

        //Delete Employee by ID
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

        //Get all Employees list
        public List<Employee> GetAllEmployees()
        {
            return getEmployeeList();
        }


        //Get Employee by id
        public Employee GetEmployeeById(int id)
        {
            return db.Employees.Find(id);
        }

        //Update employee

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

        // to get Employees in sorted order, ascending by their ID
        private List<Employee> getEmployeeList()
        {
            return db.Employees.OrderBy(e => e.Id).ToList();
        }

        //Mapper to change EmployeeDto to Employee object
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
