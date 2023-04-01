using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Contracts
{
    internal interface IGetDataInformationService
    {
        void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument);
    }
}