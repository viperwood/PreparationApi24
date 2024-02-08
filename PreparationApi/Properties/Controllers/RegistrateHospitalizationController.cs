using Microsoft.AspNetCore.Mvc;
using PreparationApi.Models;

namespace PreparationApi.Properties.Controllers;
[Route("api/[controller]")]
[Controller]
public class RegistrateHospitalizationController : Controller
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataHospitolaze">Данные для регистрации госпитализации</param>
    /// <returns></returns>
    [HttpPost("PostRegHospitalize")]
    public IActionResult PostRegHospitalize([FromBody]RegHospitolizeToDo dataHospitolaze)
    {
        Hospitalization hospitalization = Helper.Database.Hospitalizations.Where(x => x.Code == dataHospitolaze.CodeHospitaliz).FirstOrDefault()!;
        hospitalization!.Starthospital = dataHospitolaze.DateSatrtHosp;
        Helper.Database.Update(hospitalization);
        Helper.Database.SaveChanges();
        return Ok();
    }
}