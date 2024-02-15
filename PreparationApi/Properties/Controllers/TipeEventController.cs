using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class TipeEventController : Controller
{
    [HttpGet("GetTipeEvent")]
    public IActionResult GetTipeEvent()
    {
        return Ok(Helper.Database.TypeEvents.Select(x => new
        {
            x.Eventname,
            x.Eventid
        }));
        
    }
}