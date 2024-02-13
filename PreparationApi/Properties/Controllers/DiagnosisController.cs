using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class DiagnosisController : Controller
{
    [HttpGet("GetDiagnosis")]
    public IActionResult GetDiagnosis()
    {
        return Ok(Helper.Database.Diagnoses.Select(x => x.Diagnosisname).ToList());
    }
}