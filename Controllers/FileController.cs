using EmployeeAdminPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> UplopadFile([FromForm] FileUploadModel model)
        {
            if(model.File is null && model.File.Length == 0)
            {
                return BadRequest("Invalid file");
            }


            var folderName = Path.Combine("resource", "filepath");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            var fileName = model.File.FileName;
            var fullPath = Path.Combine(pathToSave, fileName);

            var dbPath = Path.Combine(folderName, fileName);


            //if (System.IO.File.Exists(fullPath))
            //{
            //    return BadRequest("file already exists");
            //}

            using (var steam = new FileStream(fullPath, FileMode.Create))
            {
                model.File.CopyTo(steam);
            }
                                

            return Ok(new{ dbPath});
        }
    }
}
