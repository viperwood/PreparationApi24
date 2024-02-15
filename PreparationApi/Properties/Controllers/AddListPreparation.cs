using Microsoft.AspNetCore.Mvc;
using PreparationApi.Models;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class AddListPreparation : Controller
{
    [HttpPost("PostListPriporation")]
    public IActionResult PostListPriporation([FromBody]List<ListPreporationDirection> preporationList)
    {
        Prescribedmedication prescribedmedication = new Prescribedmedication();
        foreach (var preporat in preporationList)
        {
            prescribedmedication.Dosage = preporat.Dosa;
            prescribedmedication.Receptionformat = preporat.Format;
            prescribedmedication.Pmid = null;
            prescribedmedication.Recommendations = preporat.Recomendation;
            prescribedmedication.Madicationsid = Helper.Database.Medications
                .Where(x => x.Medicationsname == preporat.NamePreparation).Select(x => x.Medicationsid).ToList()[0];
            prescribedmedication.Resultpmid = Helper.Database.Results.Where(x => x.Diagnosis == SaveResultId.ResultId).Select(x => x.Resultsid).ToList()[0];
            Helper.Database.Prescribedmedications.Add(prescribedmedication);
            Helper.Database.SaveChanges();
        }
        return Ok();
    }
}

public class Test
{
    public int? Madicationsid { get; set; }

    public int Resultpmid { get; set; }

    public int? Procedureid { get; set; }

    public string? Dosage { get; set; }

    public string? Receptionformat { get; set; }

    public string? Recommendations { get; set; }
}