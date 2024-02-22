using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class DirectionCheduleController : Controller
{
    [HttpGet("DirectionCheduleGet")]
    public IActionResult DirectionCheduleGet()
    {
        return Ok(Helper.Database.Directionschedules);
    }
}