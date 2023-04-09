using LattesDataExtraction.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LattesDataExtraction.API.EntryPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LattesDataExtractionController : ControllerBase
    {
        private readonly ILattesDataExtractionService _lattesDataExtractionService;
        public LattesDataExtractionController(ILattesDataExtractionService lattesDataExtractionService)
        {
            _lattesDataExtractionService = lattesDataExtractionService;
        }

        [HttpPost(Name = "AcademicResearcher")]
        public string Post(IFormFile file)
        {







            //_lattesDataExtractionService.Extract()



            return "It's working";
        }
    }
}