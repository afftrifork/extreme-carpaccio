using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ExtreameCappacio.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExtreameCappacio.Api.Controllers;

[ApiController]
[ApiConventionType(typeof(DefaultApiConventions))]
[Route("[controller]")]
public class FeedbackController : ControllerBase
{
    /// <summary>
    /// Log Feedback
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> Post()
    {
        var jsonRequest = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

        Console.WriteLine(jsonRequest);

        var feedback = JsonSerializer.Deserialize<Feedback>(jsonRequest);

        Console.WriteLine($"{feedback.type}: {feedback.content}");

        return Ok();
    }
}
