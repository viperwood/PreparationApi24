using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class Patients1Controller : Controller
{
    [HttpGet("GetPatientsFromBed")]
    public IActionResult GetPatientsFromBed()
    {
        return Ok(Helper.Database.Patients1.Select(x => new
        {
            x.Idpatients,
            x.Patientsname
        }));
    }
}