using LattesDataExtraction.Application.Models;

namespace LattesDataExtraction.Application.Contracts
{
    public interface IAcademicResearcherReadService
    {
        Task<IEnumerable<AcademicResearcherModel>> GetAll();
        Task<AcademicResearcherModel> GetById(Guid academicReseracherId);
    }
}