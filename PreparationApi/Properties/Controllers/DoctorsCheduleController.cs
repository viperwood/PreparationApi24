using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class DoctorsCheduleController : Controller
{
    [HttpGet("DoctorsCheduleGet")]
    public IActionResult DoctorsCheduleGet()
    {
        return Ok(Helper.Database.Doctorschedules);
    }
}