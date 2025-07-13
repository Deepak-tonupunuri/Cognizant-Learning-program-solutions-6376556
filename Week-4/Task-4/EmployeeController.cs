using Microsoft.AspNetCore.Mvc;
using WebApi.Filters; // For CustomAuthFilter

[ApiController]
[Route("api/[controller]")]
[ServiceFilter(typeof(CustomAuthFilter))]
public class EmployeeController : ControllerBase
{
    private readonly List<Employee> _employees;

    public EmployeeController()
    {
        _employees = GetStandardEmployeeList();
    }

    private List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 60000,
                Permanent = true,
                DateOfBirth = new DateTime(1990, 5, 23),
                Department = new Department { Id = 1, Name = "IT" },
                Skills = new List<Skill> {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = "SQL" }
                }
            }
        };
    }
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Employee), 200)]
    [ProducesResponseType(400)]
    public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
        if (existingEmployee == null)
        {
            return BadRequest("Invalid employee id");
        }

        // Update existing employee properties
        existingEmployee.Name = employee.Name;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.Permanent = employee.Permanent;
        existingEmployee.Department = employee.Department;
        existingEmployee.Skills = employee.Skills;
        existingEmployee.DateOfBirth = employee.DateOfBirth;

        return Ok(existingEmployee);
    }
}
