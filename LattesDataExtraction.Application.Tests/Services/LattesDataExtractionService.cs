using LattesDataExtraction.Domain.Contracts;

namespace LattesDataExtraction.Application.Tests.Services
{
    internal class LattesDataExtractionService : ILattesDataExtractionService
    {
        private readonly IAcademicResearcherDataExtractionService _academicResearcherDataExtractionService;

        public LattesDataExtractionService(IAcademicResearcherDataExtractionService academicResearcherDataExtractionService)
        {
            _academicResearcherDataExtractionService = academicResearcherDataExtractionService;
        }

        public AddAcademicResearcherResponse Extract(AddAcademicResearcherRequest request)
        {
            throw new NotImplementedException();
        }
    }
}