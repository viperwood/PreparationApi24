using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Route("api/[controller]")]
[Controller]
public class DiagnosisNameController : Controller
{
    [HttpGet("DiagnosisGet")]
    public IActionResult DiagnosisGet()
    {
        return Ok(Helper.Database.Diagnoses.Select(x => x.Diagnosisname));
    }
}