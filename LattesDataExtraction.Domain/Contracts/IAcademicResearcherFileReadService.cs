using LattesDataExtraction.Domain.Entities;

namespace LattesDataExtraction.Domain.Contracts
{
    internal interface IAcademicResearcherFileReadService
    {
        AcademicResearch? GetAcademicInformation(string academicResearcherFile);
    }
}