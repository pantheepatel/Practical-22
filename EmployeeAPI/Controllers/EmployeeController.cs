using EmployeeDAL.Models;
using EmployeeDAL.Services;
using EmployeeDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _repo;

        // Inject the repository via constructor
        public EmployeeController(EmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = _repo.GetById(id);
            LoggerService.Log($"Fetched employee with ID {id}");
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _repo.GetAll();
            LoggerService.Log("Fetched all employees");
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            _repo.Create(emp);
            LoggerService.Log($"Created employee {emp.EmployeeName}");
            return Ok("Employee added");
        }

        [HttpPut]
        public IActionResult Update(Employee emp)
        {
            _repo.Update(emp);
            LoggerService.Log($"Updated employee ID {emp.EmployeeId}");
            return Ok("Employee updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.SoftDelete(id);
            LoggerService.Log($"Soft deleted employee ID {id}");
            return Ok("Employee soft deleted");
        }
    }
}
