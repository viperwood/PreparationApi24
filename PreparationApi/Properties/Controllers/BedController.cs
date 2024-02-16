using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class BedController : Controller
{
    [HttpGet("GetBed")]
    public IActionResult GetBed()
    {
        return Ok(Helper.Database.Bedtipes.Select(x => new
        {
            x.Bedname,
            x.Idbed
        }));
    }
}