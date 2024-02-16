using System.Net.Mime;
using System.Drawing.Imaging;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;




namespace PreparationApi.Properties.Controllers;
[Controller]
[Route("api/[controller]")]
public class TestImage : Controller
{
    [HttpGet("TestImageGet")]
    public IActionResult TestImageGet()
    {
        return Ok();
    }
}