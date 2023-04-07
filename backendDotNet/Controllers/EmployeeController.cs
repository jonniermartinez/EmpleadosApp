using backendDotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace backendDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Email = "johndoe@example.com",
                Phone = 1234567890,
                Salary = 50000,
                Department = "IT"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Jane Smith",
                Email = "janesmith@example.com",
                Phone = 9876543210,
                Salary = 60000,
                Department = "Marketing"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Bob Johnson",
                Email = "bobjohnson@example.com",
                Phone = 5555555555,
                Salary = 75000,
                Department = "Sales"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Alice Lee",
                Email = "alicelee@example.com",
                Phone = 1111111111,
                Salary = 40000,
                Department = "HR"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Tom Wilson",
                Email = "tomwilson@example.com",
                Phone = 2222222222,
                Salary = 80000,
                Department = "IT"
            }
        };

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return CreatedAtAction(nameof(GetAllEmployees), employees);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, Employee employee)
        {
            var index = employees.FindIndex(e => e.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            employee.Id = id;
            employees[index] = employee;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employees.Remove(employee);
            return NoContent();
        }
    }
}
