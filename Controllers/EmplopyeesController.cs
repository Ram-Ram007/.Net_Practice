using EmployeeAdminPortal.Data;
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
    }
}
