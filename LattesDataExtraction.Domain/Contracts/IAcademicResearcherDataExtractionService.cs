using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Domain.Contracts
{
    internal interface IAcademicResearcherDataExtractionService
    {
        AcademicResearcher? GetAcademicInformation(string academicResearcherFile);
    }
}