using Microsoft.AspNetCore.Mvc;

namespace LattesDataExtraction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LattesDataExtractionController : ControllerBase
    {
        public LattesDataExtractionController()
        {
        }

        //[HttpPost(Name = "PostAcademicResearcher")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}