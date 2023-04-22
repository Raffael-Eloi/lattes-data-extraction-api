using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Domain.Contracts
{
    public interface IAcademicResearcherRepository
    {
        Task AddAsync(AcademicResearcher academicResearcher);
    }
}