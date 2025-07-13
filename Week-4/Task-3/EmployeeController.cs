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

    [HttpGet("GetStandard")]
    [ProducesResponseType(typeof(Employee), 200)]
    [ProducesResponseType(404)]
    public ActionResult<Employee> GetStandard()
    {
        var employee = _employees.FirstOrDefault();
        if (employee == null)
            return NotFound("No employee found");

        return Ok(employee);
    }


    [HttpGet]
    [ProducesResponseType(typeof(List<Employee>), 200)]
    public ActionResult<List<Employee>> Get()
    {
        return Ok(_employees);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Employee employee)
    {
        _employees.Add(employee);
        return Ok(employee);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Employee employee)
    {
        var existing = _employees.FirstOrDefault(e => e.Id == id);
        if (existing == null) return NotFound();
        existing.Name = employee.Name;
        existing.Salary = employee.Salary;
        existing.Permanent = employee.Permanent;
        existing.Department = employee.Department;
        existing.Skills = employee.Skills;
        existing.DateOfBirth = employee.DateOfBirth;
        return Ok(existing);
    }
}
