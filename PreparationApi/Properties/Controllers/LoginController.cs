using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class LoginController : Controller
{
    [HttpGet("GetLogin")]
    public IActionResult GetLogin(string loginUser)
    {
        return Ok(Helper.Database.Users.Where(x => x.Email == loginUser && x.Roleuser == 2).Select(x => new
        {
            x.Fio,
            x.Email
        }).ToList());
    }
}