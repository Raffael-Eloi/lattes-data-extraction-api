using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal interface IGetDataInformationService
    {
        void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument);
    }
}