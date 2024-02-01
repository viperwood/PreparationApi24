using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class GenderController : Controller
{
    [HttpGet("GetGender")]
    public IActionResult GetGender()
    {
        return Ok(Helper.Database.Genders
            .Select(x => new 
            {
                x.Gendername
            }));
    }
}