using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class PriparationController : Controller
{
    [HttpGet("GetPriparation")]
    public IActionResult GetPriparation()
    {
        return Ok(Helper.Database.Medications.Select(x => x.Medicationsname).ToList());
    }
}