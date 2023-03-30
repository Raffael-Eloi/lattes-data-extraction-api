namespace LattesDataExtraction.Domain.Tests.Services
{
    internal interface IAcademicResearcherFileReadService
    {
        AcademicResearch GetAcademicInformation(string academicResearcherFile);
    }
}