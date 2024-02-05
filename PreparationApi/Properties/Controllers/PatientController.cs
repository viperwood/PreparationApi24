using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Route("api/[controller]")]
[Controller]
public class PatientController : Controller
{
    [HttpGet("GetPatient")]
    public IActionResult GetPatient()
    {
        return Ok(Helper.Database.Users.Where(x => x.Roleuser == 3).Select(x => new
        {
            x.Fio
        }).ToList());
    }
}