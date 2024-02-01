using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class PlaceWorkController : Controller
{
    [HttpGet("GetPlaceWork")]
    public IActionResult GetPlaceWorkid()
    {
        return Ok(Helper.Database.Placeofworks
            .Select(x => new
            {
                x.Placeofworkname
            }));
    }
}