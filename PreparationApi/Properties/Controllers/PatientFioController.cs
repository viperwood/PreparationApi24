using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;

[Controller]
[Route("api/[controller]")]
public class PatientFioController : Controller
{
    [HttpGet("GetFioPatient")]
    public IActionResult GetFioPatient()
    {
        return Ok(Helper.Database.Users.Where(x => x.Roleuser == 3).Select(x => x.Fio).ToList());
    }

}