using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class PlaningController : Controller
{
    [HttpGet("PlaningGet")]
    public IActionResult PlaningGet(int month)
    {
        return Ok(Helper.Database.Schedules.Where(x => x.Timeschedule.Month == month));
    }
}