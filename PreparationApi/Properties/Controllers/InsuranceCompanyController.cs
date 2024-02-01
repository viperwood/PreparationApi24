using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class InsuranceCompanyController : Controller
{
    [HttpGet("GetInsuranceCompany")]
    public IActionResult GetInsuranceCompany()
    {
        return Ok(Helper.Database.Insurancecompanies
            .Select(x => new
            {
                x.Insurancecompanyname
            }));
    }
}