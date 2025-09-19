using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    //local host that the port the app is runing
    [Route("api/[controller]")]
    [ApiController]
    public class EmplopyeesController : ControllerBase
    {
        private readonly ApplicationDbcontext dbcontext;

        public EmplopyeesController(ApplicationDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbcontext.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbcontext.Employees.Find(id);
            if(employee is null)
            {
                return NotFound();
            }
            return Ok(employee);

        }







        [HttpPost]


           public IActionResult setallEMployees(AddEmployeeDto addEmployeeDto)
        {
            var emplopyeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };
            dbcontext.Employees.Add(emplopyeeEntity);
            dbcontext.SaveChanges();

            return Ok(emplopyeeEntity);
        }
    }
}
