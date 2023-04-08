namespace LattesDataExtraction.Application.Tests.Services
{
    internal interface ILattesDataExtractionService
    {
        AddAcademicResearcherResponse Extract(AddAcademicResearcherRequest request);
    }
}