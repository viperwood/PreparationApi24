using Microsoft.AspNetCore.Mvc;
using PreparationApi.Models;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class RegistrationController : Controller
{
    [HttpPost("PostReg")]
    public IActionResult PostReg(RegTodo content)
    {
        User user = new User();
        Patient patient = new Patient();
        Medialcard medialcard = new Medialcard();
        if (Helper.Database.Patients
                .Where(x => x.Numberpolis == content.numberpolis)
                .Count() == 0)
        {
            if (Helper.Database.Users
                    .Where(x => x.Numberp == content.numberp && x.Seriesp == content.numberp)
                    .Count() == 0)
            {
                user.Email = content.email;
                user.Address = content.address;
                user.Gender = Helper.Database.Genders
                    .Where(x => x.Gendername == content.genders)
                    .Select(x => x.Genderid)
                    .ToList()[0];
                user.Numberp = content.numberp;
                user.Roleuser = 3;
                user.Seriesp = content.serialp;
                user.Birthday = content.birthday;
                user.Phone = content.phone;
                user.Fio = content.fio;
                Helper.Database.Users.Add(user);
                Helper.Database.SaveChanges();
            }
            patient.Dataissuemc = content.dataissuemc;
            patient.Useridpatient = Helper.Database.Users
                .Where(x => x.Email == content.email)
                .Select(x => x.Userid)
                .ToList()[0];
            patient.Dataexpirationinsurancepolisy = content.dataexpirationinsurancepolisy;
            patient.Numberpolis = content.numberpolis;
            patient.Policyvalidity = content.policyvalidity;
            patient.Placeofworkid = Helper.Database.Placeofworks
                .Where(x => x.Placeofworkname == content.placeofworksid)
                .Select(x => x.Placeofworkid)
                .ToList()[0];
            patient.Insurancecompanyid = Helper.Database.Insurancecompanies
                .Where(x => x.Insurancecompanyname == content.insurancecompanysid)
                .Select(x=> x.Insurancecompanyid)
                .ToList()[0];
            Helper.Database.Patients.Add(patient);
            Helper.Database.SaveChanges();
            medialcard.Datalastvisit = DateTime.Now;
            medialcard.Diagnosisid = 4;
            medialcard.Patientid = Helper.Database.Patients
                .Where(x => x.Numberpolis == content.numberpolis)
                .Select(x => x.Patientid)
                .ToList()[0];
            Helper.Database.Medialcards.Add(medialcard);
            Helper.Database.SaveChanges();
            return Ok("Пациент добавлен");
        }
        return Ok("Пациент уже есть");
    }
}