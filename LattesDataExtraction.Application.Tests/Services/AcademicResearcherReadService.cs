using LattesDataExtraction.Application.Models;
using LattesDataExtraction.Domain.Contracts;

namespace LattesDataExtraction.Application.Tests.Services
{
    internal class AcademicResearcherReadService : IAcademicResearcherReadService
    {
        private readonly IAcademicResearcherRepository _academicResearcherRepository;

        public AcademicResearcherReadService(IAcademicResearcherRepository academicResearcherRepository)
        {
            _academicResearcherRepository = academicResearcherRepository;
        }

        public async Task<IEnumerable<AcademicResearcherModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}