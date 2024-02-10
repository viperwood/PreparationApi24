using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class FullInfoPatientController : Controller
{
    [HttpGet("GetFullInfoPatient")]
    public IActionResult GetFullInfoPatient(string name)
    {
        return Ok(Helper.Database.Patientfullinfos.Where(x => x.Fio == name));
    }
}