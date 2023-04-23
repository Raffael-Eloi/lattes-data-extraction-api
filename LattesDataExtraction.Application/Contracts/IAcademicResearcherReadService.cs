using LattesDataExtraction.Application.Models;

namespace LattesDataExtraction.Application.Contracts
{
    public interface IAcademicResearcherReadService
    {
        Task<IEnumerable<AcademicResearcherModelResponse>> GetAll();

        Task<AcademicResearcherModelResponse> GetById(Guid academicReseracherId);
    }
}