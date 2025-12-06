using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DTOs;
using EmployeeAPI.Services;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound(new { message = $"Employee with id {id} not found" });
            }

            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = new Employee
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                DateOfBirth = createDto.DateOfBirth,
                EducationLevel = createDto.EducationLevel
            };

            var createdEmployee = await _employeeService.CreateAsync(employee);
            
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
        }

        // PUT: api/employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEmployee = await _employeeService.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound(new { message = $"Employee with id {id} not found" });
            }

            existingEmployee.FirstName = updateDto.FirstName;
            existingEmployee.LastName = updateDto.LastName;
            existingEmployee.DateOfBirth = updateDto.DateOfBirth;
            existingEmployee.EducationLevel = updateDto.EducationLevel;

            await _employeeService.UpdateAsync(existingEmployee);

            return NoContent();
        }

        // DELETE: api/employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound(new { message = $"Employee with id {id} not found" });
            }

            await _employeeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
