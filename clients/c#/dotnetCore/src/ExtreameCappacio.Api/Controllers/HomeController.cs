using Microsoft.AspNetCore.Mvc;

namespace ExtreameCappacio.Api.Controllers;

[ApiController]
[ApiConventionType(typeof(DefaultApiConventions))]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}
