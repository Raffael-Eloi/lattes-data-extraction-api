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

        public LattesDataExtractionService(IAcademicResearcherDataExtractionService academicResearcherDataExtractionService, IMapper mapper)
        {
            _academicResearcherDataExtractionService = academicResearcherDataExtractionService;
            _mapper = mapper;
        }

        public AddAcademicResearcherResponse Extract(AddAcademicResearcherRequest request)
        {
            AcademicResearcher? academicResearcher = _academicResearcherDataExtractionService.GetAcademicInformation(request.File);

            return _mapper.Map<AddAcademicResearcherResponse>(academicResearcher);
        }
    }
}