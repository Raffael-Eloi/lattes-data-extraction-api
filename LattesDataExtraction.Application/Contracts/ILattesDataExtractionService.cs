using LattesDataExtraction.Application.Models;

namespace LattesDataExtraction.Application.Contracts
{
    public interface ILattesDataExtractionService
    {
        AddAcademicResearcherResponse Extract(AddAcademicResearcherRequest request);
    }
}