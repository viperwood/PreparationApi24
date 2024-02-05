using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class PlaceWorkController : Controller
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Список работ</returns>
    [HttpGet("GetPlaceWork")]
    //Гет запрос на выбор места работы
    public IActionResult GetPlaceWorkid()
    {
        return Ok(Helper.Database.Placeofworks
            .Select(x => new
            {
                x.Placeofworkname
            }));
    }
}