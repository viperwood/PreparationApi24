using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Route("api/[controller]")]
[Controller]
public class RefusalController : Controller
{
    [HttpGet("GetRefusal")]
    public IActionResult GetRefusal(string code)
    {
        var refus = Helper.Database.Hospitalizations.Where(x => x.Code.ToString() == code).FirstOrDefault();
        refus!.Refusal = true;
        Helper.Database.Hospitalizations.Update(refus);
        Helper.Database.SaveChanges();
        return Ok();
    }
}