using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController> get all employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _employeeService.GetAllEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return _employeeService.GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<IEnumerable<Employee>> Post([FromBody] EmployeeDto createDto)
        {
            var updatedEmployeeList = _employeeService.AddEmployee(createDto);
            return new ActionResult<IEnumerable<Employee>>(updatedEmployeeList);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Employee>> Update(int id, [FromBody] Employee employee)
        {
            var updatedEmployeeList = _employeeService.UpdateEmployee(employee);
            return new ActionResult<IEnumerable<Employee>>(updatedEmployeeList);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_employeeService.DeleteEmployee(id)) {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
