using LattesDataExtraction.Application.Models;
using System.Xml;

namespace LattesDataExtraction.Application.Contracts
{
    public interface ILattesDataExtractionService
    {
        Task<AddAcademicResearcherResponse> Extract(XmlDocument document);
    }
}