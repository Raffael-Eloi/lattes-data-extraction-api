using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Domain.Contracts
{
    public interface IAcademicResearcherRepository
    {
        Task AddAsync(AcademicResearcher academicResearcher);

        Task<AcademicResearcher> GetById(Guid id);

        Task<IEnumerable<AcademicResearcher>> GetAll();
    }
}