using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Domain.Contracts
{
    public interface IAcademicResearcherRepository
    {
        public void Save(AcademicResearcher academicResearcher);
    }
}