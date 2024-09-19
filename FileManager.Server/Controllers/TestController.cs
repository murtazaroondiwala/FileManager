using Microsoft.AspNetCore.Mvc;

namespace FileManager.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestController : Controller
{
    public TestController()
    {
        
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello World now!");
    }
}