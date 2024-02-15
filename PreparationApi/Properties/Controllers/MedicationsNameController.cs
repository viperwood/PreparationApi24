using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Route("api/[controller]")]
[Controller]
public class MedicationsNameController : Controller
{
    [HttpGet("MedicationsGet")]
    public IActionResult MedicationsGet()
    {
        return Ok(Helper.Database.Medications.Select(x=> x.Medicationsname).ToList());
    }
}