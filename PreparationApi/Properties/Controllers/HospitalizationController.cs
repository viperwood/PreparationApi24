using Microsoft.AspNetCore.Mvc;
using PreparationApi.Models;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class HospitalizationController : Controller
{
    [HttpGet("GetHospitolization")]
    public IActionResult GetHospitolization(int code)
    {
        if (code != null)
        {
            return Ok(Helper.Database.Hospitalizs.Where(x => x.Code == code));
        }
        return Ok();
    }
}