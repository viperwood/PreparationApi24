using Microsoft.AspNetCore.Mvc;
using PreparationApi.Models;

namespace PreparationApi.Properties.Controllers;
[Route("api/[controller]")]
[Controller]
public class CancellationController : Controller
{
    [HttpPost("PostCancellation")]
    public IActionResult PostCancellation([FromBody]CancellationText information)
    {
        var cancellat = Helper.Database.Hospitalizations.Where(x => x.Code.ToString() == information.Code)
            .FirstOrDefault();
        cancellat!.Cancellation = information.Description;
        Helper.Database.Hospitalizations.Update(cancellat);
        Helper.Database.SaveChanges();
        return Ok();
    }
}