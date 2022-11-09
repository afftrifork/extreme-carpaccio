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
public class OrderController : ControllerBase
{
    /// <summary>
    /// Compute total from input order.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> Post()
    {
        var jsonRequest = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        Console.WriteLine(jsonRequest);
        var order = JsonSerializer.Deserialize<Order>(jsonRequest);

        var response = new OrderResponse
        {
            total = 3000
        };
        return Ok(response);
    }
}
