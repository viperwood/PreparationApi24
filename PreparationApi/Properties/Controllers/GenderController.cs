using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class GenderController : Controller
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Список гендеров</returns>
    [HttpGet("GetGender")]
    //Гет запрос на выбор пола
    public IActionResult GetGender()
    {
        return Ok(Helper.Database.Genders
            .Select(x => new 
            {
                x.Gendername
            }));
    }
}