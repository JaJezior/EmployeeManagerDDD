using EmployeeManagerDomain.Requests;
using EmployeeManagerDomain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public void AddEmployee([FromBody] AddEmployeeRequest addEmployeeRequest)
        {
            _employeeService.CreateNew(addEmployeeRequest);
        }

        [HttpPut("{employeeId}")]
        public void UpdateEmployee(Guid employeeId, [FromBody] UpdateEmployeeRequest updateEmployeeRequest)
        {
            _employeeService.Update(employeeId, updateEmployeeRequest);
        }
    }
}