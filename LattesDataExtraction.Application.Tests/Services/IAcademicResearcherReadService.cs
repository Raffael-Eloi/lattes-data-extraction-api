using LattesDataExtraction.Application.Models;

namespace LattesDataExtraction.Application.Tests.Services
{
    internal interface IAcademicResearcherReadService
    {
        Task<IEnumerable<AcademicResearcherModel>> GetAll();
    }
}