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
