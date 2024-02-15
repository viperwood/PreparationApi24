using Microsoft.AspNetCore.Mvc;
using PreparationApi.Models;

namespace PreparationApi.Properties;
[Controller]
[Route("api/[controller]")]
public class AddDirection : Controller
{
    [HttpPost("PostDirection")]
    public IActionResult PostDirection([FromBody]AddInfoDirectori info)
    {
        Random random = new Random();
        Medialcard medialcard = new Medialcard();
        Diagnostic diagnostic = new Diagnostic();
        Result result = new Result();
        Prescribedmedication prescribedmedication = new Prescribedmedication();
        var user = info.Fio;
        var patient = Helper.Database.Patients.Where(x => x.Useridpatient == user).Select(x => x.Patientid).ToList();
        var diagnos = info.Diagnos;
        medialcard.Diagnosisid = diagnos!.Value;
        medialcard.Patientid = patient[0];
        medialcard.Datalastvisit = DateTime.Now;
        medialcard.Anamnesis = info.Anamnis;
        do
        {
            medialcard.Datanextvisit = DateTime.Now + new TimeSpan(1,0,0,0);
        } while (Helper.Database.Medialcards.Where(x => x.Datanextvisit == medialcard.Datanextvisit).Count()>0);
        medialcard.Symptoms = info.Symptomatic;
        if (Helper.Database.Medialcards.Where(x => x.Patientid == patient[0]).Select(x => x.Medialcardcod).Count() > 0)
        {
            var cod = Helper.Database.Medialcards.Where(x => x.Patientid == patient[0]).Select(x => x.Medialcardcod)
                .ToList();
            medialcard.Medialcardcod = cod[0];
        }
        else
        {
            medialcard.Medialcardcod = random.Next(10000000, 99999999);
        }
        Helper.Database.Medialcards.Add(medialcard);
        Helper.Database.SaveChanges();
        diagnostic.Doctor = info.DoctorId;
        diagnostic.Tipeeventid = info.TipeEvent;
        diagnostic.Datadiagnostic = DateTime.Now;
        diagnostic.Diagnosticname = info.NameDiagnostic;
        diagnostic.Medialcardid = Helper.Database.Medialcards
            .Where(x => x.Medialcardcod == medialcard.Medialcardcod && x.Symptoms == medialcard.Symptoms)
            .Select(x => x.Mcid).ToList()[0];
        Helper.Database.Diagnostics.Add(diagnostic);
        Helper.Database.SaveChanges();
        
        result.Description = info.Description;
        SaveResultId.ResultId = Helper.Database.Diagnostics
            .Where(x => x.Diagnosticname == diagnostic.Diagnosticname && x.Medialcardid == diagnostic.Medialcardid &&
                        x.Doctor == diagnostic.Doctor).Select(x => x.Diagnosticid).ToList()[0];
        result.Diagnosis = SaveResultId.ResultId;
        Helper.Database.Results.Add(result);
        Helper.Database.SaveChanges();
        return Ok();
    }
}