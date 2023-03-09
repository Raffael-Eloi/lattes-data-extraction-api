using Microsoft.AspNetCore.Mvc;

namespace lattes_data_extraction_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LattesExtractionController : ControllerBase
    {
        [HttpPost(Name = "RegisterUserAcademicData")]
        public IEnumerable<WeatherForecast> Post()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }
    }
}