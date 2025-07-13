using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/emp")] // changed from [controller] to 'emp'
    public class EmployeeController : ControllerBase

    {
        [HttpGet]
        public IActionResult Get()
        {
            var employees = new[]
            {
                new { Id = 1, Name = "John", Department = "Developer" },
                new { Id = 2, Name = "Vick", Department = "Service Manager" },
            };
            return Ok(employees);
        }
    }
}
