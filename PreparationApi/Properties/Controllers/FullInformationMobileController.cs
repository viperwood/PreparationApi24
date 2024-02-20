using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class FullInformationMobileController : Controller
{
    [HttpGet("GetPatientMobile")]
    public IActionResult GetPatientMobile(int idPatienta)
    {
        return Ok(Helper.Database.Patientfullinfos.Where(x => x.Userid == idPatienta));
    }
}