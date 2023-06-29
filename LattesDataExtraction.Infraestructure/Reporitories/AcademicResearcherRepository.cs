using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LattesDataExtraction.Infraestructure.Reporitories
{
    internal class AcademicResearcherRepository : IAcademicResearcherRepository
    {
        private readonly AcademicResearcherEFContext _academicResearcherContext;

        public static IDictionary<Guid, AcademicResearcher> academicResearchersById = new Dictionary<Guid, AcademicResearcher>();

        public AcademicResearcherRepository(AcademicResearcherEFContext academicResearcherContext)
        {
            _academicResearcherContext = academicResearcherContext;
        }

        public async Task AddAsync(AcademicResearcher academicResearcher)
        {
            await _academicResearcherContext.AcademicResearchers.AddAsync(academicResearcher);

            await _academicResearcherContext.SaveChangesAsync();

            academicResearchersById[academicResearcher.Id] = academicResearcher;
        }

        public async Task<AcademicResearcher?> GetById(Guid id)
        {
            return academicResearchersById[id];

            return await _academicResearcherContext.AcademicResearchers.FindAsync(id);
        }

        public async Task<IEnumerable<AcademicResearcher>> GetAll()
        {
            return academicResearchersById.Values.ToList();
            return await _academicResearcherContext.AcademicResearchers.ToListAsync();
        }
    }
}