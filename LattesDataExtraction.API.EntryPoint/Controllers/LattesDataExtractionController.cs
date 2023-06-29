using LattesDataExtraction.Application.Contracts;
using LattesDataExtraction.Application.Models;
using LattesDataExtraction.Infraestructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace LattesDataExtraction.API.EntryPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LattesDataExtractionController : ControllerBase
    {
        private readonly ILattesDataExtractionService _lattesDataExtractionService;

        private readonly IAcademicResearcherReadService _academicResearcherReadService;
        public LattesDataExtractionController(ILattesDataExtractionService lattesDataExtractionService, 
            IAcademicResearcherReadService academicResearcherReadService)
        {
            _lattesDataExtractionService = lattesDataExtractionService;
            _academicResearcherReadService = academicResearcherReadService;
        }

        [HttpPost(Name = "PostAcademicResearcher")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            if (FileIsNotInXMLFormat(file))
            {
                var errorsMessages = GetInvalidFormatFileErrorMessage();

                return StatusCode(StatusCodes.Status400BadRequest, errorsMessages);
            }

            XmlDocument academicResearcherDocument = LoadXMLFile(file);

            AddAcademicResearcherResponse response = await _lattesDataExtractionService.Extract(academicResearcherDocument);

            if (response.IsValid)
            {
                return Ok(response);
            }

            return ValidationProblem(ModelState.AddErrorsFromNotifications(response.Notifications));
        }


        private static bool FileIsNotInXMLFormat(IFormFile file)
        {
            return file.ContentType != "text/xml";
        }

        private static XmlDocument LoadXMLFile(IFormFile file)
        {
            XmlDocument academicResearcherDocument = new();

            academicResearcherDocument.Load(file.OpenReadStream());
            return academicResearcherDocument;
        }

        private static object GetInvalidFormatFileErrorMessage()
        {
            IEnumerable<string> errorsMessages = new string[] { "The file must be in format text/xml" };
            object errorMapper = new { file = errorsMessages };
            var messages = new { status = 400, errors = errorMapper };
            return messages;
        }

        [HttpGet("{academicResearcherId:Guid}", Name = "GetAcademicResearcherById")]
        public async Task<IActionResult> Get([Required] Guid academicResearcherId)
        {
            AcademicResearcherModelResponse response = await _academicResearcherReadService.GetById(academicResearcherId);

            if (!response.IsValid)
            {
                return ValidationProblem(ModelState.AddErrorsFromNotifications(response.Notifications));
            }

            return Ok(response);
        }

        [HttpGet(Name = "GetAllAcademicResearchers")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<AcademicResearcherModelResponse> response = await _academicResearcherReadService.GetAll();

            return Ok(response);
        }
    }
}