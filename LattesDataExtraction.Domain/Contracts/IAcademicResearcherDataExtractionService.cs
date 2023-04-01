using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Domain.Contracts
{
    internal interface IAcademicResearcherDataExtractionService
    {
        AcademicResearch? GetAcademicInformation(string academicResearcherFile);
    }
}