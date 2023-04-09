using LattesDataExtraction.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

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
        public async Task<IActionResult> Post(IFormFile file)
        {
            if (file.ContentType != "text/xml") 
            {
                var errorsMessages = GetInvalidFormatFileErrorMessage();

                return StatusCode(StatusCodes.Status400BadRequest, errorsMessages);
            }

            XmlDocument academicResearcherDocument = new();

            academicResearcherDocument.Load(file.OpenReadStream());


            //_lattesDataExtractionService.Extract()



            return Ok();
        }

        private static object GetInvalidFormatFileErrorMessage()
        {
            IEnumerable<string> errorsMessages = new string[] { "The file must be in format text/xml" };
            object errorMapper = new { file = errorsMessages };
            var messages = new { status = 400, errors = errorMapper };
            return messages;
        }
    }
}