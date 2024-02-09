using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class FullInfoPatientController : Controller
{
    [HttpGet("GetFullInfoPatient")]
    public IActionResult GetFullInfoPatient(string name)
    {
        string nameId = Helper.Database.Users.Where(x => x.Fio == name).Select(x => x.Userid).ToString()!;
        return Ok(Helper.Database.Patients.Where(x => x.Useridpatient.ToString() == nameId));
    }
}