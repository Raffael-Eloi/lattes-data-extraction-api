using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Infraestructure.Context;

namespace LattesDataExtraction.Infraestructure.Reporitories
{
    internal class AcademicResearcherRepository : IAcademicResearcherRepository
    {
        private readonly AcademicResearcherContext _academicResearcherContext;

        public AcademicResearcherRepository(AcademicResearcherContext academicResearcherContext)
        {
            _academicResearcherContext = academicResearcherContext;
        }

        public async Task AddAsync(AcademicResearcher academicResearcher)
        {
            await _academicResearcherContext.AcademicResearchers.AddAsync(academicResearcher);
        }
    }
}