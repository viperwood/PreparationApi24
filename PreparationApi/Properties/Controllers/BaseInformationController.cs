using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class BaseInformationController : Controller
{
    [HttpGet("GetInfo")]
    public IActionResult GetInfo()
    {
        return Ok(Helper.Database.Patients);
    }
}