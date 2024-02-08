using Microsoft.AspNetCore.Mvc;
using PreparationApi.Models;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class HospitalizationController : Controller
{
    [HttpGet("GetHospitolization")]
    public IActionResult GetHospitolization(int code, string? name)
    {
        if (code != null && name != null)
        {
            return Ok(Helper.Database.Hospitalizs.Where(x => x.Code == code && x.Fio == name));
        }
        return Ok();
    }
}