using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Domain.Contracts
{
    public interface IAcademicResearcherDataExtractionService
    {
        AcademicResearcher? GetAcademicInformation(string academicResearcherFile);
    }
}