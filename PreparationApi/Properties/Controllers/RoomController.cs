using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class RoomController : Controller
{
    [HttpGet("GetRoom")]
    public IActionResult GetRoom()
    {
        return Ok(Helper.Database.Rooms.Select(x => new
        {
            x.Roomname,
            x.Idroom
        }));
    }
}