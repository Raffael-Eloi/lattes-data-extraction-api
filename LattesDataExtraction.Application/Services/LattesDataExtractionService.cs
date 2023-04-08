using AutoMapper;
using LattesDataExtraction.Application.Contracts;
using LattesDataExtraction.Application.Models;
using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Application.Services
{
    public class LattesDataExtractionService : ILattesDataExtractionService
    {
        private readonly IAcademicResearcherDataExtractionService _academicResearcherDataExtractionService;

        private readonly IMapper _mapper;

        private readonly IAcademicResearcherRepository _academicResearcherRepository;

        private const string DataFileInvalidMessage = "The data on the XML file is invalid.";

        public LattesDataExtractionService(
                IAcademicResearcherDataExtractionService academicResearcherDataExtractionService, 
                IMapper mapper, 
                IAcademicResearcherRepository academicResearcherRepository
            )
        {
            _academicResearcherDataExtractionService = academicResearcherDataExtractionService;
            _mapper = mapper;
            _academicResearcherRepository = academicResearcherRepository;
        }

        public AddAcademicResearcherResponse Extract(AddAcademicResearcherRequest request)
        {
            AcademicResearcher? academicResearcher = _academicResearcherDataExtractionService.GetAcademicInformation(request.File);

            if (RequestIsInvalid(academicResearcher, out AddAcademicResearcherResponse invalidResponse))
            {
                return invalidResponse;
            }

            if ( academicResearcher != null ) 
            {
                _academicResearcherRepository.Save(academicResearcher);
            }

            return _mapper.Map<AddAcademicResearcherResponse>(academicResearcher);
        }

        private static bool RequestIsInvalid(AcademicResearcher? academicResearcher, out AddAcademicResearcherResponse invalidResponse)
        {
            invalidResponse = new AddAcademicResearcherResponse();

            if ( academicResearcher == null )
            {
                invalidResponse.AddNotification("AcademicResearcher", DataFileInvalidMessage);
            }

            return !invalidResponse.IsValid;
        }
    }
}