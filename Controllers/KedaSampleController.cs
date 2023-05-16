using Microsoft.AspNetCore.Mvc;

namespace keda_demo.Controllers;

[ApiController]
[Route("[controller]")]
public class KedaSampleController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<KedaSampleController> _logger;

    public KedaSampleController(ILogger<KedaSampleController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetKedaSample")]
    public IEnumerable<KedaSample> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new KedaSample
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
