using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Contracts
{
    public interface IAcademicResearcherDataExtractionService
    {
        AcademicResearcher GetAcademicInformation(XmlDocument document);
    }
}