using Microsoft.AspNetCore.Mvc;
using PreparationApi.Models;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class BedOccupancyController : Controller
{
    [HttpPost("PostRegBed")]
    public IActionResult PostRegBed([FromBody] AddBedPatient info)
    {
        int count = Helper.Database.Bedoccupancies.Where(x => x.Idroom == info.Idroom).Count();
        if (Helper.Database.Rooms.Where(x => x.Idroom == info.Idroom).Select(x => x.Countbed).ToList()[0] > count)
        {
            if (Helper.Database.Bedoccupancies.Where(x => x.Bedid == info.Bedid).Count() == 0)
            {
                if (Helper.Database.Bedoccupancies.Where(x => x.Patientsid == info.Patientsid).Count() == 0)
                {
                    Bedoccupancy bedoccupancy = new Bedoccupancy();
                    bedoccupancy.Bedid = info.Bedid;
                    bedoccupancy.Patientsid = info.Patientsid;
                    bedoccupancy.Idroom = info.Idroom;
                    Helper.Database.Bedoccupancies.Add(bedoccupancy);
                    Helper.Database.SaveChanges(); 
                }
                else
                {
                    Bedoccupancy bedoccupancy = new Bedoccupancy();
                    bedoccupancy.Bedid = info.Bedid;
                    bedoccupancy.Patientsid = info.Patientsid;
                    bedoccupancy.Idroom = info.Idroom;
                    Helper.Database.Bedoccupancies.Update(bedoccupancy);
                    Helper.Database.SaveChanges(); 
                }
            }
        }
        return Ok();
    }
}
public class AddBedPatient
{   
    public int Idroom { get; set; }
    public int Bedid { get; set; }
    public int Patientsid { get; set; }
}