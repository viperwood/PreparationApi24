using Microsoft.AspNetCore.Mvc;

namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class RandomController : Controller
{
    [HttpGet("GetRandom")]
    public IActionResult GetRandom()
    {
        List<Rand> randomUsers = new List<Rand>();
        Random random = new Random();
        for (int i = 0; i < 100; i++)
        {
            Rand rand = new Rand();
            int PersonCode = random.Next(1, 100);
            int PersonRole = random.Next(1, 100);
            int LastSecurityPointNumber = random.Next(1, 100);
            int LastSecurityPointDirection = random.Next(1, 100);
            int minutes = random.Next(0, 59);
            int seconds = random.Next(0, 59);
            int hours = random.Next(0, 59);
            int days = random.Next(0, 30);
            DateTime LastSecurityPointTime = DateTime.Now + new TimeSpan(days,hours,minutes,seconds);
            rand.PersonCode = PersonCode;
            rand.LastSecurityPointNumber = LastSecurityPointNumber;
            rand.PersonRole = PersonRole < 51 ? "Клиент" : "Сотрудник";
            rand.LastSecurityPointDirection = LastSecurityPointDirection < 51 ? "in" : "out";
            rand.LastSecurityPointTime = LastSecurityPointTime;
            randomUsers.Add(rand);
        }
        return Ok(randomUsers);
    }
}

public class Rand
{
    public int PersonCode { get; set; }
    public string? PersonRole { get; set; }
    public int LastSecurityPointNumber { get; set; }
    public string? LastSecurityPointDirection { get; set; }
    public DateTime LastSecurityPointTime { get; set; }
}