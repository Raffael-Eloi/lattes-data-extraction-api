using LattesDataExtraction.Application.Models;
using System.Xml;

namespace LattesDataExtraction.Application.Contracts
{
    public interface ILattesDataExtractionService
    {
        AddAcademicResearcherResponse Extract(XmlDocument document);
    }
}