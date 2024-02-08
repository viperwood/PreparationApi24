using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Route("api/[controller]")]
[Controller]
public class HospitalizationInfoController : Controller
{
    [HttpGet("GethospitalizationInfo")]
    public IActionResult GethospitalizationInfo(string code)
    {
        return Ok(Helper.Database.Hospitalizs.Where(x => x.Code.ToString() == code));
    }
}