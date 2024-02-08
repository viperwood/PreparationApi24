using Microsoft.AspNetCore.Mvc;
using PreparationApi.Models;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class RegistrationController : Controller
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="registrationmodel">Данные для регистрации пользователя</param>
    /// <returns></returns>
    [HttpPost("PostReg")]
    //Пост запрос для регистрации
    public IActionResult PostReg([FromBody]RegTodo registrationmodel)
    {
        
        User user = new User();
        Patient patient = new Patient();
        Medialcard medialcard = new Medialcard();
        //Проверка на наличие пациента 
        if (Helper.Database.Patients
                .Where(x => x.Numberpolis == registrationmodel.Numberpolis)
                .Count() == 0)
        {
            //Проверка на наличие юзера в базе
            
            if (Helper.Database.Users
                    .Where(x => x.Numberp == registrationmodel.Numberp && x.Seriesp == registrationmodel.Numberp)
                    .Count() == 0)
            {
                //Добавление юзера
                user.Email = registrationmodel.Email;
                user.Address = registrationmodel.Address;
                user.Gender = Helper.Database.Genders
                    .Where(x => x.Gendername == registrationmodel.Genders)
                    .Select(x => x.Genderid)
                    .ToList()[0];
                user.Numberp = registrationmodel.Numberp;
                user.Roleuser = 3;
                user.Seriesp = registrationmodel.Serialp;
                user.Birthday = registrationmodel.Birthday;
                user.Phone = registrationmodel.Phone;
                user.Fio = registrationmodel.Fio;
                Helper.Database.Users.Add(user);
                Helper.Database.SaveChanges();
            }
            //Добавление пациента
            patient.Dataissuemc = registrationmodel.Dataissuemc;
            patient.Useridpatient = Helper.Database.Users
                .Where(x => x.Email == registrationmodel.Email)
                .Select(x => x.Userid)
                .ToList()[0];
            patient.Dataexpirationinsurancepolisy = registrationmodel.Dataexpirationinsurancepolisy;
            patient.Numberpolis = registrationmodel.Numberpolis;
            patient.Policyvalidity = registrationmodel.Policyvalidity;
            patient.Placeofworkid = Helper.Database.Placeofworks
                .Where(x => x.Placeofworkname == registrationmodel.Placeofworksid)
                .Select(x => x.Placeofworkid)
                .ToList()[0];
            patient.Insurancecompanyid = Helper.Database.Insurancecompanies
                .Where(x => x.Insurancecompanyname == registrationmodel.Insurancecompanysid)
                .Select(x=> x.Insurancecompanyid)
                .ToList()[0];
            Helper.Database.Patients.Add(patient);
            Helper.Database.SaveChanges();
            //Добавление медицинской карты
            Random random = new Random();
            medialcard.Datalastvisit = DateTime.Now;
            medialcard.Datanextvisit = new DateTime(9999);
            medialcard.Diagnosisid = 4;
            int cod;
            do
            {
                cod = random.Next(10000000,99999999);
            } while (Helper.Database.Medialcards.Where(x => x.Medialcardcod == cod).Count() == 1);
            medialcard.Medialcardcod = cod;
            medialcard.Patientid = Helper.Database.Patients
                .Where(x => x.Numberpolis == registrationmodel.Numberpolis)
                .Select(x => x.Patientid)
                .ToList()[0];
            Helper.Database.Medialcards.Add(medialcard);
            Helper.Database.SaveChanges();
            return Ok("Пациент добавлен");
        }
        return Ok("Пациент уже был добавлен");
    }
}