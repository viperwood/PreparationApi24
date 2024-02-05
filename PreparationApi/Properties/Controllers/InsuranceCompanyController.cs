using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class InsuranceCompanyController : Controller
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Список страховых компаний</returns>
    [HttpGet("GetInsuranceCompany")]
    //Гет запрос на выбор страховой компании
    public IActionResult GetInsuranceCompany()
    {
        return Ok(Helper.Database.Insurancecompanies
            .Select(x => new
            {
                x.Insurancecompanyname
            }));
    }
}